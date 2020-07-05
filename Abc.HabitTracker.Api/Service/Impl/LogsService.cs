using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Repository;
using Abc.HabitTracker.Api.Factory;
using Abc.HabitTracker.Api.Event;
using System.Collections.Generic;
using System.Linq;

namespace Abc.HabitTracker.Api.Service.Impl
{
    public class LogsService : ILogsService, IObservableCustom<Badge>
    {
        private readonly ILogsRepository logsRepository;
        private readonly IBadgeService badgeService;

        private readonly IDayOffRepository dayOffRepository;
        public LogsService(ILogsRepository _logsRepository, IBadgeService _badgeService, IDayOffRepository _dayOffRepository)
        {
            logsRepository = _logsRepository;
            badgeService = _badgeService;
            dayOffRepository = _dayOffRepository;
        }


        private bool isWorkaholic(Dictionary<Guid, List<DateTime>> HabitAndLogs)
        {
            int count = 0;
            List<DateTime> dateTimes = new List<DateTime>();
            foreach (var item in HabitAndLogs)
            {
                List<String> dayOffList = dayOffRepository.GetDayOffByHabitId(item.Key);
                foreach (DateTime date in item.Value)
                {
                    if (dayOffList.Contains(date.DayOfWeek.ToString().Substring(0, 3)) && !dateTimes.Contains(date))
                    {
                        count++;
                        dateTimes.Add(date);
                    }
                    if (count == 10)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool isEpicComeback(Logs logs)
        {
            List<String> dayOffs = dayOffRepository.GetDayOffByHabitId(logs.HabitID);
            List<DateTime> habits = logsRepository.GetAllLogsTime(logs.HabitID);
            DateTime date = habits[0];
            int workCount = 1;
            int skipCount = 0;
            for (int j = 0; j < habits.Count - 1; j++)
            {
                if (DateTime.Compare(habits[j], habits[j + 1]) == -1)
                {
                    workCount++;
                }
                else if (!dayOffs.Contains(habits[j].DayOfWeek.ToString().Substring(0, 3)))
                {
                    workCount = 1;
                    date = habits[j];
                }
                if (workCount == 10)
                {
                    date = date.AddDays(-1);
                    while (true)
                    {
                        if (!habits.Contains(date) && !dayOffs.Contains(date.DayOfWeek.ToString().Substring(0, 3)))
                        {
                            skipCount++;
                        }
                        if (skipCount == 10)
                        {
                            return true;
                        }
                        if (habits.Contains(date) && !dayOffs.Contains(date.DayOfWeek.ToString().Substring(0, 3)))
                        {
                            return false;
                        }
                        date = date.AddDays(-1);
                    }
                }
            }
            return false;
        }

        private bool isDominating(Logs logs)
        {
            List<DateTime> dateTimes = logsRepository.GetAllLogsTime(logs.HabitID);
            List<String> dayOffs = dayOffRepository.GetDayOffByHabitId(logs.HabitID);
            int count = 1;
            for (int j = 0; j < dateTimes.Count - 1; j++)
            {
                if (DateTime.Compare(dateTimes[j], dateTimes[j + 1]) == -1)
                {
                    count++;
                }
                else if (!dayOffs.Contains(dateTimes[j].DayOfWeek.ToString().Substring(0, 3)))
                {
                    count = 1;
                }
                if (count == 4)
                {
                    return true;
                }
            }

            return false;
        }

        public Logs CreateLogs(Logs logs)
        {
            logsRepository.CreateLogs(logs);
            Dictionary<Guid, List<DateTime>> HabitAndLogs = logsRepository.GetHabitAndLogsFromUserID(logs.UserID);
            BadgeHandler badge = new BadgeHandler(badgeService);
            Attach(badge);
            if (isDominating(logs))
            {
                Broadcast(BadgeFactory.CreateBadge("Dominating", logs.UserID));
            }
            if (isWorkaholic(HabitAndLogs))
            {
                Broadcast(BadgeFactory.CreateBadge("Workaholic", logs.UserID));
            }
            if (isEpicComeback(logs))
            {
                Broadcast(BadgeFactory.CreateBadge("Epic Comeback", logs.UserID));
            }
            return logs;
        }

        public Int32 GetCurrentStreak(Guid HabitId)
        {
            return logsRepository.GetCurrentStreak(HabitId);
        }
        public Int32 GetLongestStreak(Guid HabitId)
        {
            return logsRepository.GetLongestStreak(HabitId);
        }
        public Int32 GetLogCount(Guid HabitId)
        {
            return logsRepository.GetLogCount(HabitId);
        }
        public List<DateTime> GetAllLogsTime(Guid HabitId)
        {
            return logsRepository.GetAllLogsTime(HabitId);
        }

        protected List<IObserverCustom<Badge>> observers = new List<IObserverCustom<Badge>>();
        public void Attach(IObserverCustom<Badge> obs)
        {
            observers.Add(obs);
        }

        public void Broadcast(Badge e)
        {
            foreach (var obs in observers)
            {
                obs.Update(e);
            }
        }

        public Logs GetLatestSubmission(Guid HabitID)
        {
            return logsRepository.GetLatestLogSubmission(HabitID);
        }

        public bool IsEmptyLog(Guid HabitID)
        {
            return logsRepository.IsEmptyLog(HabitID);
        }
    }
}
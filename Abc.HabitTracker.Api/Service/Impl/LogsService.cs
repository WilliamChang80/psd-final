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


        public bool isWorkaholic(Dictionary<Guid, List<DateTime>> HabitAndLogs)
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

        public bool isEpicComeback(Logs logs)
        {
            return false;
        }

        public bool isDominating(Logs logs)
        {
            List<String> dayOffList = dayOffRepository.GetDayOffByHabitId(logs.HabitID);
            int count = 0;
            foreach (String str in dayOffList)
            {
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
            //datetime udah beda
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

        public Int16 GetCurrentStreak(Guid HabitId)
        {
            return logsRepository.GetCurrentStreak(HabitId);
        }
        public Int16 GetLongestStreak(Guid HabitId)
        {
            return logsRepository.GetLongestStreak(HabitId);
        }
        public Int16 GetLogCount(Guid HabitId)
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
    }
}
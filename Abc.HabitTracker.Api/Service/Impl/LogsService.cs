using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Repository;
using Abc.HabitTracker.Api.Factory;
using Abc.HabitTracker.Api.Event;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Service.Impl
{
    public class LogsService : ILogsService, IObservableCustom<Badge>
    {
        private readonly ILogsRepository logsRepository;
        private readonly IBadgeService badgeService;
        public LogsService(ILogsRepository _logsRepository, IBadgeService _badgeService)
        {
            logsRepository = _logsRepository;
            badgeService = _badgeService;
        }

        public Logs CreateLogs(Logs logs)
        {
            logsRepository.CreateLogs(logs);
            Dictionary<Guid, List<DateTime>> HabitAndLogs = logsRepository.GetHabitAndLogsFromUserID(logs.UserID);
            BadgeHandler badge = new BadgeHandler(badgeService);
            Attach(badge);
            foreach (var item in HabitAndLogs)
            {
                if (item.Value.Count >= 4)
                {
                    Broadcast(BadgeFactory.CreateBadge("Dominating", logs.UserID));
                }
                //other badge
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
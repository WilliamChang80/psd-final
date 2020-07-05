using Abc.HabitTracker.Api.Repository;
using System;
using Abc.HabitTracker.Api.Entity;
using System.Linq;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Repository.Impl
{
    public class LogsRepositoryPostgre : ILogsRepository
    {
        private ApplicationDbContext applicationDb;

        public LogsRepositoryPostgre(ApplicationDbContext _applicationDb)
        {
            applicationDb = _applicationDb;
        }
        public Logs CreateLogs(Logs logs)
        {
            applicationDb.Logs.Add(logs);
            applicationDb.SaveChanges();
            return logs;
        }

        public Int32 GetCurrentStreak(Guid HabitId)
        {
            Int32 currentStreak = IsEmptyLog(HabitId) ? 0 :
            applicationDb.Logs
            .Where(h => h.HabitID == HabitId)
            .OrderByDescending(l => l.CreatedAt)
            .Select(l => l.Streak)
            .First();

            return currentStreak;
        }
        public Int32 GetLongestStreak(Guid HabitId)
        {
            Int32 longestStreak = IsEmptyLog(HabitId) ? 0 :
            applicationDb.Logs
            .Where(h => h.HabitID == HabitId)
            .Max(h => h.Streak);

            return longestStreak;
        }
        public Int32 GetLogCount(Guid HabitId)
        {
            return (Int32)applicationDb.Logs
            .Where(l => l.HabitID == HabitId)
            .Count();
        }
        public List<DateTime> GetAllLogsTime(Guid HabitId)
        {
            return applicationDb.Logs
            .Where(l => l.HabitID == HabitId)
            .Select(l => l.CreatedAt)
            .OrderBy(l => l)
            .ToList();
        }

        public Dictionary<Guid, List<DateTime>> GetHabitAndLogsFromUserID(Guid UserID)
        {
            List<Habit> habits = applicationDb.Habits
            .Where(habit => habit.UserID == UserID)
            .ToList();
            Dictionary<Guid, List<DateTime>> HabitAndLogsList = new Dictionary<Guid, List<DateTime>>();
            foreach (Habit habit in habits)
            {
                List<DateTime> dateTimes = GetAllLogsTime(habit.ID).Distinct()
                .OrderBy(x => x)
                .ToList();
                HabitAndLogsList.Add(habit.ID, dateTimes);
            }
            return HabitAndLogsList;
        }

        public Logs GetLatestLogSubmission(Guid HabitId)
        {
            return applicationDb.Logs
                    .Where(h => h.HabitID == HabitId)
                    .OrderByDescending(l => l.CreatedAt)
                    .First();
        }

        public bool IsEmptyLog(Guid HabitID)
        {
            return applicationDb.Logs.Where(h => h.HabitID == HabitID).Count() == 0;
        }
    }
}
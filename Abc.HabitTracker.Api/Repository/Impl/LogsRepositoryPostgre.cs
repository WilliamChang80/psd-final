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
        public Habit CreateLogs(Logs logs)
        {
            return null;
        }

        public Int16 getCurrentStreak(Guid HabitId)
        {
            return 0;
        }
        public Int16 getLongestStreak(Guid HabitId)
        {
            return 0;
        }
        public Int16 getLogCount(Guid HabitId)
        {
            return (Int16)applicationDb.Logs
            .Where(l => l.HabitID == HabitId)
            .Count();
        }
        public List<DateTime> GetAllLogsTime(Guid HabitId)
        {
            return applicationDb.Logs
            .Where(l => l.HabitID == HabitId)
            .Select(l => l.CreatedAt)
            .ToList();
        }
    }
}
using Abc.HabitTracker.Api.Repository;
using System;
using Abc.HabitTracker.Api.Entity;

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

    }
}
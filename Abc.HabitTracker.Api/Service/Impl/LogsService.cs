using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Repository;

namespace Abc.HabitTracker.Api.Service.Impl
{
    public class LogsService : ILogsService
    {
        private readonly ILogsRepository logsRepository;

        public LogsService(ILogsRepository _logsRepository)
        {
            logsRepository = _logsRepository;
        }
        public Habit CreateLogs(Logs logs)
        {
            return null;
        }
    }
}
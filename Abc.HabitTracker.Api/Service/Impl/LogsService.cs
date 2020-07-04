using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Repository;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Service.Impl
{
    public class LogsService : ILogsService
    {
        private readonly ILogsRepository logsRepository;

        public LogsService(ILogsRepository _logsRepository)
        {
            logsRepository = _logsRepository;
        }

        public Logs CreateLogs(Logs logs)
        {
            return logsRepository.CreateLogs(logs);
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
    }
}
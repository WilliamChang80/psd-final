using Abc.HabitTracker.Api.Dto;
using System;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Repository
{
    public interface ILogsRepository
    {
        //changed to DTO later
        Logs CreateLogs(Logs logs);
        Int16 getCurrentStreak(Guid HabitId);
        Int16 getLongestStreak(Guid HabitId);
        Int16 getLogCount(Guid HabitId);
        List<DateTime> GetAllLogsTime(Guid HabitId);
    }
}
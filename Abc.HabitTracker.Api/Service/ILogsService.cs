using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Service
{
    public interface ILogsService
    {
        Logs CreateLogs(Logs logs);

        Int32 GetCurrentStreak(Guid HabitId);

        Int32 GetLongestStreak(Guid HabitId);

        Int32 GetLogCount(Guid HabitId);

        List<DateTime> GetAllLogsTime(Guid HabitId);


    }
}
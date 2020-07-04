using Abc.HabitTracker.Api.Dto;
using System;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Repository
{
    public interface ILogsRepository
    {
        Logs CreateLogs(Logs logs);
        Int16 GetCurrentStreak(Guid HabitId);
        Int16 GetLongestStreak(Guid HabitId);
        Int16 GetLogCount(Guid HabitId);
        List<DateTime> GetAllLogsTime(Guid HabitId);

        Dictionary<Guid, List<DateTime>> GetHabitAndLogsFromUserID(Guid UserID);
    }
}
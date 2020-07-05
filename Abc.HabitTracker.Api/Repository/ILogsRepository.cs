using Abc.HabitTracker.Api.Dto;
using System;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Repository
{
    public interface ILogsRepository
    {
        Logs CreateLogs(Logs logs);
        Int32 GetCurrentStreak(Guid HabitId);
        Int32 GetLongestStreak(Guid HabitId);
        Int32 GetLogCount(Guid HabitId);
        List<DateTime> GetAllLogsTime(Guid HabitId);

        Dictionary<Guid, List<DateTime>> GetHabitAndLogsFromUserID(Guid UserID);
        Logs GetLatestLogSubmission(Guid HabitId);

        bool IsEmptyLog(Guid HabitID);
    }
}
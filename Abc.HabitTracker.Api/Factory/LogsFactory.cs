using System;
using Abc.HabitTracker.Api.Dto;
using System.Globalization;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Factory
{
    class LogsFactory
    {

        public static Logs CreateLogs(Habit habit, Int32 StreakCount)
        {
            return new Logs(Guid.NewGuid(), habit.UserID, habit.ID, DateTime.Now, StreakCount);
        }
    }
}
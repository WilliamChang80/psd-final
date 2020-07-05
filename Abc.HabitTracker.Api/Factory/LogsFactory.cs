using System;
using Abc.HabitTracker.Api.Dto;
using System.Globalization;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Factory
{
    class LogsFactory
    {

        public static Logs CreateLogs(Habit habit)
        {
            const Int32 INITIAL_STREAK_COUNT = 0;

            return new Logs(Guid.NewGuid(), habit.UserID, habit.ID, DateTime.Now, INITIAL_STREAK_COUNT);
        }
    }
}
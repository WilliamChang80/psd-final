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
            return new Logs(Guid.NewGuid(), habit.UserID, habit.ID,
            System.DateTime.Now.DayOfWeek.ToString().Substring(0, 3), DateTime.Now);
        }
    }
}
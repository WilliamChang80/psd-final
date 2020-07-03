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
            return new Logs()
            {
                LogsID = Guid.NewGuid(),
                UserID = habit.UserID,
                HabitID = habit.ID,
                DayName = System.DateTime.Now.DayOfWeek.ToString().Substring(0, 3),
                CreatedAt = DateTime.Now
            };
        }
    }
}
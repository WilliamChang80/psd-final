using System;
using Abc.HabitTracker.Api.Dto;
using System.Globalization;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Factory
{
    class HabitFactory
    {
        public static List<DayOff> CreateDayOff(List<String> DaysOff)
        {
            List<DayOff> DayOffList = new List<DayOff>();
            foreach (String day in DaysOff)
            {
                DayOff dayOff = new DayOff(day);
                DayOffList.Add(dayOff);
            }
            return DayOffList;
        }
        public static Habit Create(HabitRequest habitRequest, Guid UserID)
        {
            List<DayOff> dayOffList = CreateDayOff(habitRequest.DaysOff);
            return new Habit(Guid.NewGuid(), habitRequest.Name, UserID, DateTime.Now, dayOffList);
        }

        public static Habit CreateUpdatedData(HabitRequest habitRequest, Habit oldHabit)
        {
            List<DayOff> dayOffList = CreateDayOff(habitRequest.DaysOff);
            return new Habit(oldHabit.ID, habitRequest.Name, oldHabit.UserID, oldHabit.CreatedAt, dayOffList);
        }
    }
}
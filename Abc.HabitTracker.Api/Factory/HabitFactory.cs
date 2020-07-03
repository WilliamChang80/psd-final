using System;
using Abc.HabitTracker.Api.Dto;
using System.Globalization;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Factory
{
    class HabitFactory
    {
        public List<DayOff> CreateDayOff(List<String> DaysOff)
        {
            List<DayOff> DayOffList = new List<DayOff>();
            foreach (String day in DaysOff)
            {
                DayOff dayOff = new DayOff();
                dayOff.DayName = day;
                DayOffList.Add(dayOff);
            }
            return DayOffList;
        }
        public Habit Create(HabitRequest habitRequest, Guid UserID)
        {
            List<DayOff> dayOffList = CreateDayOff(habitRequest.DaysOff);
            return new Habit()
            {
                ID = Guid.NewGuid(),
                Name = habitRequest.Name,
                UserID = UserID,
                CreatedAt = DateTime.Now,
                DayOffList = dayOffList
            };
        }

        public Habit CreateUpdatedData(HabitRequest habitRequest, Habit oldHabit)
        {
            List<DayOff> dayOffList = CreateDayOff(habitRequest.DaysOff);
            return new Habit()
            {
                ID = oldHabit.ID,
                Name = habitRequest.Name,
                UserID = oldHabit.UserID,
                CreatedAt = oldHabit.CreatedAt,
                DayOffList = dayOffList
            };
        }
    }
}
using System;
using Abc.HabitTracker.Api.Dto;
using System.Globalization;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Factory
{
    class DayOffFactory
    {
        public static List<DayOff> Create(List<String> dayList, Guid habitId)
        {
            List<DayOff> dayOffList = new List<DayOff>();
            foreach (String day in dayList)
            {
                DayOff dayOff = new DayOff(day)
                {
                    HabitID = habitId
                };
                dayOffList.Add(dayOff);
            }
            return dayOffList;
        }
    }
}
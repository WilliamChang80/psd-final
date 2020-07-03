using Abc.HabitTracker.Api.Dto;
using System;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Repository
{
    public interface IDayOffRepository
    {
        List<String> GetDayOffByHabitId(Guid habitId);

        List<DayOff> CreateDayOff(List<DayOff> dayOffList);
    }
}
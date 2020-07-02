using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Service
{
    public interface IHabitService
    {
        Habit GetHabitById(Guid habitId);

        Habit CreateHabit(HabitRequest HabitRequest, Guid UserID);

        List<Habit> GetHabitByUserId(Guid userId);

        Habit DeleteHabit(Guid habitId);

        Habit UpdateHabit(Guid habitId, HabitRequest HabitRequest);
    }
}
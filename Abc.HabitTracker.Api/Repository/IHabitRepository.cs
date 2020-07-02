using Abc.HabitTracker.Api.Dto;
using System;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Repository
{
    public interface IHabitRepository
    {
        Habit GetHabitById(Guid habitId);
        Habit CreateHabit(HabitRequest HabitRequest);
        Habit DeleteHabit(Guid habitId);
        List<Habit> GetHabitByUserId(Guid userId);
        Habit UpdateHabit(Guid habitId, HabitRequest HabitRequest);

    }
}
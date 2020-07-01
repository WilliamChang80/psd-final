using Abc.HabitTracker.Api.Dto;
using System;

namespace Abc.HabitTracker.Api.Repository
{
    public interface IHabitRepository
    {
        Habit GetHabitById(Guid habitId);
        Habit CreateHabit(HabitRequest HabitRequest);
        Habit DeleteHabit(Guid habitId);

        Habit UpdateHabit(Guid habitId, HabitRequest HabitRequest);

    }
}
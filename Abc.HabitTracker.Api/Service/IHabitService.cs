using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;

namespace Abc.HabitTracker.Api.Service
{
    public interface IHabitService
    {
        Habit GetHabitById(Guid habitId);

        Habit CreateHabit(HabitRequest HabitRequest);

        Habit DeleteHabit(Guid habitId);

        Habit UpdateHabit(Guid habitId, HabitRequest HabitRequest);
    }
}
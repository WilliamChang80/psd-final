using Abc.HabitTracker.Api.Repository;
using Abc.HabitTracker.Api.Dto;
using System;

namespace Abc.HabitTracker.Api.Repository.Impl
{
    public class HabitRepositoryPostgre : IHabitRepository
    {
        public Habit GetHabitById(Guid habitId)
        {
            return null;
        }
        public Habit CreateHabit(HabitRequest HabitRequest)
        {
            return null;
        }
        public Habit DeleteHabit(Guid habitId)
        {
            return null;
        }

        public Habit UpdateHabit(Guid habitId, HabitRequest HabitRequest)
        {
            return null;
        }
    }
}
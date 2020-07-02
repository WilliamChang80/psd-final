using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Repository;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Service.Impl
{
    public class HabitService : IHabitService
    {

        private readonly IHabitRepository habitRepository;

        public HabitService(IHabitRepository _habitRepository)
        {
            habitRepository = _habitRepository;
        }
        public List<Habit> GetHabitByUserId(Guid userID)
        {
            return habitRepository.GetHabitByUserId(userID);
        }
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
using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Repository;
using Abc.HabitTracker.Api.Factory;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Abc.HabitTracker.Api.Service.Impl
{
    public class HabitService : IHabitService
    {

        private readonly IHabitRepository habitRepository;

        private readonly IUserRepository userRepository;

        public HabitService(IHabitRepository _habitRepository, IUserRepository _userRepository)
        {
            habitRepository = _habitRepository;
            userRepository = _userRepository;
        }
        public List<Habit> GetHabitByUserId(Guid userID)
        {
            return habitRepository.GetHabitByUserId(userID);
        }
        public Habit GetHabitById(Guid habitId)
        {
            return null;
        }
        public Habit CreateHabit(HabitRequest HabitRequest, Guid UserID)
        {
            HabitFactory habitFactory = new HabitFactory();
            Habit habit = habitFactory.Create(HabitRequest, UserID);
            return habitRepository.CreateHabit(habit);
        }
        public Habit DeleteHabit(Guid userId, Guid habitId)
        {
            User user = userRepository.GetUserById(userId);
            if (user is null)
            {
                throw new Exception("User not Found !");
            }
            Habit habit = habitRepository.GetHabitById(habitId);
            if (userId != habit.UserID)
            {
                throw new Exception("User ID and User ID in Habit Must Match !");
            }
            habitRepository.DeleteHabit(habitId);
            return habit;
        }

        public Habit UpdateHabit(Guid habitId, HabitRequest HabitRequest)
        {
            return null;
        }
    }
}
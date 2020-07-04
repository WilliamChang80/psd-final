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

        private readonly ILogsRepository logsRepository;

        private readonly IDayOffRepository dayOffRepository;
        public HabitService(IHabitRepository _habitRepository, IUserRepository _userRepository,
        ILogsRepository _logsRepository, IDayOffRepository _dayOffRepository)
        {
            habitRepository = _habitRepository;
            userRepository = _userRepository;
            logsRepository = _logsRepository;
            dayOffRepository = _dayOffRepository;
        }

        public HabitResponse GetRequiredDataFromLogs(Guid HabitId)
        {
            Int16 CurrentStreak = logsRepository.getCurrentStreak(HabitId);
            Int16 LongestStreak = logsRepository.getLongestStreak(HabitId);
            Int16 LogCount = logsRepository.getLogCount(HabitId);
            List<DateTime> Logs = logsRepository.GetAllLogsTime(HabitId);

            return new HabitResponse()
            {
                CurrentStreak = CurrentStreak,
                LongestStreak = LongestStreak,
                LogCount = LogCount,
                Logs = Logs
            };
        }
        public HabitResponse ConvertFromHabitToHabitResponse(Habit habit)
        {
            HabitResponse logs = GetRequiredDataFromLogs(habit.ID);
            List<String> list = dayOffRepository.GetDayOffByHabitId(habit.ID);
            return new HabitResponse()
            {
                ID = habit.ID,
                Name = habit.Name,
                DayOffList = list,
                //currentStreak get from database logs
                CurrentStreak = logs.CurrentStreak,
                //currentStreak get from database logs
                LongestStreak = logs.LongestStreak,
                LogCount = logs.LogCount,
                Logs = logs.Logs,
                UserID = habit.UserID,
                CreatedAt = habit.CreatedAt
            };
        }
        private void ValidateUserID(Guid userId, Guid habitId)
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
        }

        public HabitResponse ConvertFromHabitToHabitResponseByRemovingDayOff(Habit habit, List<String> dayOffList)
        {
            HabitResponse logs = GetRequiredDataFromLogs(habit.ID);
            return new HabitResponse()
            {
                ID = habit.ID,
                Name = habit.Name,
                DayOffList = dayOffList,
                //currentStreak get from database logs
                CurrentStreak = logs.CurrentStreak,
                //currentStreak get from database logs
                LongestStreak = logs.LongestStreak,
                LogCount = logs.LogCount,
                Logs = logs.Logs,
                UserID = habit.UserID,
                CreatedAt = habit.CreatedAt
            };
        }

        public List<HabitResponse> GetHabitByUserId(Guid userID)
        {
            List<Habit> habitList = habitRepository.GetHabitByUserId(userID);
            List<HabitResponse> habitResponseList = new List<HabitResponse>();
            foreach (Habit habit in habitList)
            {
                HabitResponse habitResponse = ConvertFromHabitToHabitResponse(habit);
                habitResponseList.Add(habitResponse);
            }
            return habitResponseList;
        }
        public HabitResponse GetHabitById(Guid userId, Guid habitId)
        {
            ValidateUserID(userId, habitId);
            Habit habit = habitRepository.GetHabitById(habitId);
            return ConvertFromHabitToHabitResponse(habit);
        }
        public HabitResponse CreateHabit(HabitRequest HabitRequest, Guid UserID)
        {
            HabitFactory habitFactory = new HabitFactory();
            Habit habit = habitFactory.Create(HabitRequest, UserID);
            List<DayOff> dayOffs = DayOffFactory.Create(HabitRequest.DaysOff, habit.ID);
            habitRepository.CreateHabit(habit);
            dayOffRepository.CreateDayOff(dayOffs);
            return ConvertFromHabitToHabitResponse(habit);
        }
        public HabitResponse DeleteHabit(Guid userId, Guid habitId)
        {
            ValidateUserID(userId, habitId);
            List<String> dayOffs = dayOffRepository.GetDayOffByHabitId(habitId);
            Habit habit = habitRepository.DeleteHabit(habitId);
            dayOffRepository.DeleteDayOff(habitId);
            return ConvertFromHabitToHabitResponseByRemovingDayOff(habit, dayOffs);
        }

        public HabitResponse UpdateHabit(Guid userId, Guid habitId, HabitRequest habitRequest)
        {
            ValidateUserID(userId, habitId);
            Habit habit = habitRepository.GetHabitById(habitId);
            HabitFactory habitFactory = new HabitFactory();
            Habit updatedHabit = habitFactory.CreateUpdatedData(habitRequest, habit);
            List<DayOff> dayOffList = DayOffFactory.Create(habitRequest.DaysOff, habit.ID);
            dayOffRepository.UpdateDayOff(dayOffList, habitId);
            habitRepository.UpdateHabit(habitId, updatedHabit);
            return ConvertFromHabitToHabitResponse(updatedHabit);
        }

        public HabitResponse CreateHabitLog(Guid userId, Guid habitId)
        {
            ValidateUserID(userId, habitId);
            Habit habit = habitRepository.GetHabitById(habitId);
            Logs logs = LogsFactory.CreateLogs(habit);
            logsRepository.CreateLogs(logs);
            return ConvertFromHabitToHabitResponse(habit);
        }
    }
}
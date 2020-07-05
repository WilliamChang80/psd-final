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

        private readonly ILogsService logsService;

        private readonly IDayOffRepository dayOffRepository;
        public HabitService(IHabitRepository _habitRepository, IUserRepository _userRepository,
        ILogsService _logsService, IDayOffRepository _dayOffRepository)
        {
            habitRepository = _habitRepository;
            userRepository = _userRepository;
            logsService = _logsService;
            dayOffRepository = _dayOffRepository;
        }

        public HabitResponse GetRequiredDataFromLogs(Guid HabitId)
        {
            Int32 CurrentStreak = logsService.GetCurrentStreak(HabitId);
            Int32 LongestStreak = logsService.GetLongestStreak(HabitId);
            Int32 LogCount = logsService.GetLogCount(HabitId);
            List<DateTime> Logs = logsService.GetAllLogsTime(HabitId);

            return new HabitResponse()
            {
                CurrentStreak = CurrentStreak,
                LongestStreak = LongestStreak,
                LogCount = LogCount,
                Logs = Logs
            };
        }
        private HabitResponse ConvertFromHabitToHabitResponse(Habit habit)
        {
            HabitResponse logs = GetRequiredDataFromLogs(habit.ID);
            List<String> list = dayOffRepository.GetDayOffByHabitId(habit.ID);
            return new HabitResponse()
            {
                ID = habit.ID,
                Name = habit.Name,
                DayOffList = list,
                CurrentStreak = logs.CurrentStreak,
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

        private HabitResponse ConvertFromHabitToHabitResponseByRemovingDayOff(Habit habit, List<String> dayOffList)
        {
            HabitResponse logs = GetRequiredDataFromLogs(habit.ID);
            return new HabitResponse()
            {
                ID = habit.ID,
                Name = habit.Name,
                DayOffList = dayOffList,
                CurrentStreak = logs.CurrentStreak,
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
            Habit habit = HabitFactory.Create(HabitRequest, UserID);
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
            Habit updatedHabit = HabitFactory.CreateUpdatedData(habitRequest, habit);
            List<DayOff> dayOffList = DayOffFactory.Create(habitRequest.DaysOff, habit.ID);
            dayOffRepository.UpdateDayOff(dayOffList, habitId);
            habitRepository.UpdateHabit(habitId, updatedHabit);
            return ConvertFromHabitToHabitResponse(updatedHabit);
        }

        public HabitResponse CreateHabitLog(Guid userId, Guid habitId)
        {
            ValidateUserID(userId, habitId);
            Habit habit = habitRepository.GetHabitById(habitId);
            Int32 streakCount = GetStreakCount(habitId);
            Logs logs = LogsFactory.CreateLogs(habit, streakCount);
            logsService.CreateLogs(logs);
            return ConvertFromHabitToHabitResponse(habit);
        }

        private Int32 GetStreakCount(Guid habitId)
        {
            if (logsService.IsEmptyLog(habitId))
            {
                return 1;
            }
            else
            {
                Logs logs = logsService.GetLatestSubmission(habitId);
                List<String> dayOffList = dayOffRepository.GetDayOffByHabitId(habitId);
                DateTime now = DateTime.Now;
                if (now.Day == logs.CreatedAt.Day && now.Month == logs.CreatedAt.Month && now.Year == now.Year)
                {
                    return logs.Streak + 1;
                }
                for (int j = 0; j < (now - logs.CreatedAt).TotalDays; j++)
                {
                    now = now.AddDays(-1);
                    if (now.Day == logs.CreatedAt.Day && now.Month == logs.CreatedAt.Month && now.Year == now.Year)
                    {
                        return logs.Streak + 1;
                    }
                    if (!dayOffList.Contains(now.DayOfWeek.ToString().Substring(0, 3)))
                    {
                        return 1;
                    }
                }
                return logs.Streak + 1;
            }
        }

    }
}
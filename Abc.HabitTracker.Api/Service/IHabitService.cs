using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Service
{
    public interface IHabitService
    {
        HabitResponse GetHabitById(Guid habitId);

        HabitResponse CreateHabit(HabitRequest HabitRequest, Guid UserID);

        List<HabitResponse> GetHabitByUserId(Guid userId);

        HabitResponse DeleteHabit(Guid userId, Guid habitId);

        HabitResponse UpdateHabit(Guid userId, Guid habitId, HabitRequest HabitRequest);

        HabitResponse CreateHabitLog(Guid userId, Guid habitId);
    }
}
using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;

namespace Abc.HabitTracker.Api.Service
{
    public interface ILogsService
    {
        Habit CreateLogs(Logs logs);
    }
}
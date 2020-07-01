using Abc.HabitTracker.Api.Dto;

namespace Abc.HabitTracker.Api.Repository
{
    public interface ILogsRepository
    {
        //changed to DTO later
        Habit CreateLogs(Logs logs);

    }
}
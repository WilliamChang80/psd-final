using Abc.HabitTracker.Api.Dto;

namespace Abc.HabitTracker.Api.Repository
{
    public interface IHabitRepository
    {
        Habit GetHabitById(Guid habitId);
        Habit CreateHabit(HabitDto habitDto);
        Habit DeleteHabit(Guid habitId);

        Habit UpdateHabit(Guid habitId, HabitDto habitDto);

    }
}
using Abc.HabitTracker.Api.Repository;
using Abc.HabitTracker.Api.Entity;
using System.Collections.Generic;
using Abc.HabitTracker.Api.Dto;
using System;
using System.Linq;

namespace Abc.HabitTracker.Api.Repository.Impl
{
    public class HabitRepositoryPostgre : IHabitRepository
    {

        private ApplicationDbContext applicationDb;

        public HabitRepositoryPostgre(ApplicationDbContext _applicationDb)
        {
            applicationDb = _applicationDb;
        }

        public List<Habit> GetHabitByUserId(Guid userId)
        {
            return applicationDb.Habits.Where(h => h.UserID == userId)
            .ToList();
        }
        public Habit GetHabitById(Guid habitId)
        {
            return applicationDb.Habits.Find(habitId);
        }
        public Habit CreateHabit(Habit habit)
        {
            applicationDb.Habits.Add(habit);
            applicationDb.SaveChanges();
            return habit;
        }
        public Habit DeleteHabit(Guid habitId)
        {
            Habit habit = GetHabitById(habitId);
            applicationDb.Habits.Remove(habit);
            applicationDb.SaveChanges();
            return habit;
        }

        public Habit UpdateHabit(Guid habitId, Habit updatedHabit)
        {
            Habit habit = GetHabitById(habitId);
            if (habit != null)
            {
                applicationDb.Entry(habit).CurrentValues.SetValues(updatedHabit);
            }
            applicationDb.SaveChanges();
            return updatedHabit;
        }
    }
}
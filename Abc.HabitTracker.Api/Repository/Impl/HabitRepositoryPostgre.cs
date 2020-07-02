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
            return null;
        }
        public Habit CreateHabit(Habit habit)
        {
            applicationDb.Habits.Add(habit);
            applicationDb.SaveChanges();
            return habit;
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
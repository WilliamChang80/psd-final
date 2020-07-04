using Abc.HabitTracker.Api.Repository;
using System;
using System.Collections.Generic;
using Abc.HabitTracker.Api.Entity;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System.Data.Entity;

namespace Abc.HabitTracker.Api.Repository.Impl
{
    public class DayOffRepositoryPostgre : IDayOffRepository
    {
        private ApplicationDbContext applicationDb;

        public DayOffRepositoryPostgre(ApplicationDbContext _applicationDb)
        {
            applicationDb = _applicationDb;
        }
        public List<String> GetDayOffByHabitId(Guid habitId)
        {
            return applicationDb.DayOffs
            .Where(l => l.HabitID == habitId)
            .Select(l => l.DayName)
            .ToList();
        }

        public List<DayOff> CreateDayOff(List<DayOff> dayOffList)
        {
            foreach (DayOff dayOff in dayOffList)
            {
                var habitID = new NpgsqlParameter("@habitID", dayOff.HabitID);
                var dayName = new NpgsqlParameter("@dayName", dayOff.DayName);
                applicationDb.Database
                .ExecuteSqlRaw("INSERT INTO habit_dayoff VALUES (@dayName, @habitID);", dayName, habitID);
            }
            applicationDb.SaveChanges();
            return dayOffList;
        }

        public List<DayOff> DeleteDayOff(Guid habitId)
        {
            List<DayOff> dayOffs = applicationDb.DayOffs
            .Where(l => l.HabitID == habitId)
            .ToList();

            foreach (DayOff d in dayOffs)
            {
                applicationDb.DayOffs.Remove(d);
            }
            applicationDb.SaveChanges();
            return dayOffs;
        }
        public List<DayOff> UpdateDayOff(List<DayOff> dayOffList, Guid habitId)
        {
            var habitID = new NpgsqlParameter("@habitID", habitId);
            applicationDb.Database
            .ExecuteSqlRaw("DELETE FROM habit_dayoff WHERE \"HabitID\" = @habitID;", habitID);
            CreateDayOff(dayOffList);
            return dayOffList;
        }
    }
}
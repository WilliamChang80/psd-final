using Abc.HabitTracker.Api.Repository;
using System;
using System.Collections.Generic;
using Abc.HabitTracker.Api.Entity;
using System.Linq;
using System.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace Abc.HabitTracker.Api.Repository.Impl
{
    public class DayOffRepositoryPostgre : IDayOffRepository
    {
        private ApplicationDbContext applicationDb;

        public DayOffRepositoryPostgre(ApplicationDbContext _applicationDb)
        {
            applicationDb = _applicationDb;
        }
        public List<String> getDayOffByHabitId(Guid habitId)
        {
            return applicationDb.DayOffs
            .Where(l => l.HabitID == habitId)
            .Select(l => l.DayName)
            .ToList();
        }
    }
}
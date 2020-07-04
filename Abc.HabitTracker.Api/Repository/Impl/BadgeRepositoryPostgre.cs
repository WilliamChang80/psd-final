using Abc.HabitTracker.Api.Repository;
using System;
using System.Collections.Generic;
using Abc.HabitTracker.Api.Entity;
using System.Linq;

namespace Abc.HabitTracker.Api.Repository.Impl
{
    public class BadgeRepositoryPostgre : IBadgeRepository
    {
        private ApplicationDbContext applicationDb;

        public BadgeRepositoryPostgre(ApplicationDbContext _applicationDb)
        {
            applicationDb = _applicationDb;
        }

        public List<Badge> GetBadgeByUserId(Guid UserId)
        {
            return applicationDb.Badges.Where(b => b.UserID == UserId)
            .ToList();
        }

        public Badge CreateBadge(Badge badge)
        {
            applicationDb.Badges.Add(badge);
            applicationDb.SaveChanges();
            return badge;
        }
    }
}
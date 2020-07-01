using Abc.HabitTracker.Api.Repository;
using System;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Repository.Impl
{
    public class BadgeRepositoryPostgre : IBadgeRepository
    {
        public IEnumerable<Badge> GetBadgeByUserId(Guid UserId)
        {
            return new[] {
                    new Badge {
                    ID = Guid.NewGuid(),
                    Name = "Dominating",
                    Description = "4+ streak",
                    CreatedAt = DateTime.Now.AddDays(-13),
                    },
                    new Badge {
                    ID = Guid.NewGuid(),
                    Name = "Epic Comeback",
                    Description = "10 streak after 10 days without logging",
                    CreatedAt = DateTime.Now.AddDays(-7),
                }
            };
        }

        public Badge CreateBadge(Badge badge)
        {
            return null;
        }
    }
}
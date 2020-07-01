using System;
using Abc.HabitTracker.Api.Repository;
using System.Collections.Generic;
using Abc.HabitTracker.Api.Service;

namespace Abc.HabitTracker.Api.Service.Impl
{
    public class BadgeService : IBadgeService
    {
        private readonly IBadgeRepository badgeRepository;

        public BadgeService(IBadgeRepository _badgeRepository)
        {
            badgeRepository = _badgeRepository;
        }
        public IEnumerable<Badge> GetBadgeByUserId(Guid UserId)
        {
            return badgeRepository.GetBadgeByUserId(UserId);
        }

        public Badge CreateBadge(Badge badge)
        {
            return null;
        }
    }
}
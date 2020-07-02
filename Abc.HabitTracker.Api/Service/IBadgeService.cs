using System;
using Abc.HabitTracker.Api.Repository;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Service
{
    public interface IBadgeService
    {
        List<Badge> GetBadgeByUserId(Guid UserId);
        Badge CreateBadge(Badge badge);
    }
}
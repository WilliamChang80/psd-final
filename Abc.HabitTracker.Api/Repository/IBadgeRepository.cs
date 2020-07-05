using Abc.HabitTracker.Api.Dto;
using System;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Repository
{
    public interface IBadgeRepository
    {
        List<Badge> GetBadgeByUserId(Guid UserId);

        Badge CreateBadge(Badge badge);

    }
}
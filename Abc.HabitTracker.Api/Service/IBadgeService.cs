using System;
using Abc.HabitTracker.Api.Repository;
using Abc.HabitTracker.Api.Dto;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Service
{
    public interface IBadgeService
    {
        List<BadgeResponse> GetBadgeByUserId(Guid UserId);
        BadgeResponse CreateBadge(Badge badge);
    }
}
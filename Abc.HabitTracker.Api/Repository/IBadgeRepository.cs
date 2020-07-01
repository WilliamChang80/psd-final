using Abc.HabitTracker.Api.Dto;
using System;

namespace Abc.HabitTracker.Api.Repository
{
    public interface IBadgeRepository
    {
        Badge GetBadgeByUserId(Guid UserId);

        //changed to DTO later
        Badge CreateBadge(Badge badge);

    }
}
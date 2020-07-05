using Abc.HabitTracker.Api.Entity;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Dto;
using System.Collections.Generic;

namespace Abc.HabitTracker.Api.Event
{
    public class BadgeHandler : IObserverCustom<Badge>
    {
        private readonly IBadgeService badgeService;
        public BadgeHandler(IBadgeService _badgeService)
        {
            badgeService = _badgeService;
        }
        public void Update(Badge badge)
        {
            List<BadgeResponse> userBadge = badgeService.GetBadgeByUserId(badge.UserID);
            foreach (BadgeResponse b in userBadge)
            {
                if (b.Name == badge.Name)
                {
                    return;
                }
            }
            badgeService.CreateBadge(badge);
        }
    }

}
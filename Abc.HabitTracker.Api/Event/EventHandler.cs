using Abc.HabitTracker.Api.Entity;
using Abc.HabitTracker.Api.Service;
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
            List<Badge> userBadge = badgeService.GetBadgeByUserId(badge.UserID);
            foreach (Badge b in userBadge)
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
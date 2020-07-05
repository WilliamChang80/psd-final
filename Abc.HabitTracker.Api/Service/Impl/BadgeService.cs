using System;
using Abc.HabitTracker.Api.Repository;
using System.Collections.Generic;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Event;
using Abc.HabitTracker.Api.Dto;

namespace Abc.HabitTracker.Api.Service.Impl
{
    public class BadgeService : IBadgeService
    {
        private readonly IBadgeRepository badgeRepository;

        public BadgeService(IBadgeRepository _badgeRepository)
        {
            badgeRepository = _badgeRepository;
        }

        private BadgeResponse ConvertToResponse(Badge badge)
        {
            return new BadgeResponse()
            {
                ID = badge.ID,
                Name = badge.Name,
                Description = badge.Description,
                UserID = badge.UserID,
                CreatedAt = badge.CreatedAt
            };
        }
        public List<BadgeResponse> GetBadgeByUserId(Guid UserId)
        {
            List<Badge> badges = badgeRepository.GetBadgeByUserId(UserId);
            List<BadgeResponse> badgeResponses = new List<BadgeResponse>();
            foreach (Badge b in badges)
            {
                BadgeResponse badgeResponse = ConvertToResponse(b);
                badgeResponses.Add(badgeResponse);
            }
            return badgeResponses;
        }

        public BadgeResponse CreateBadge(Badge badge)
        {
            badgeRepository.CreateBadge(badge);
            return ConvertToResponse(badge);
        }
    }
}
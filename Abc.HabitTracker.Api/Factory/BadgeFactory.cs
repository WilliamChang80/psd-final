using System;
using Abc.HabitTracker.Api.Dto;
using System.Globalization;
using System.Collections.Generic;
using Abc.HabitTracker.Api.Event;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Service.Impl;

namespace Abc.HabitTracker.Api.Factory
{
    class BadgeFactory
    {
        public static Badge CreateBadge(String badgeTitle, Guid UserID)
        {
            switch (badgeTitle)
            {
                case "Dominating":
                    return new Badge()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Dominating",
                        Description = "4+ streak",
                        UserID = UserID,
                        CreatedAt = DateTime.Now
                    };
                case "Workaholic":
                    return new Badge()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Workaholic",
                        Description = "Doing some works on daysoff",
                        UserID = UserID,
                        CreatedAt = DateTime.Now
                    };
                case "Epic Comeback":
                    return new Badge()
                    {
                        ID = Guid.NewGuid(),
                        Name = "Epic Comeback",
                        Description = "10 streak after 10 days without logging",
                        UserID = UserID,
                        CreatedAt = DateTime.Now
                    };
            }
            return new Badge();
        }
    }
}
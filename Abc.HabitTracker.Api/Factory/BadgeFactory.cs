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
                    return new Badge(Guid.NewGuid(), "Dominating", "4+ streak", UserID, DateTime.Now);
                case "Workaholic":
                    return new Badge(Guid.NewGuid(), "Workaholic", "Doing some works on daysoff", UserID, DateTime.Now);
                case "Epic Comeback":
                    return new Badge(Guid.NewGuid(), "Epic Comeback", "10 streak after 10 days without logging", UserID, DateTime.Now);
            }
            return new Badge();
        }
    }
}
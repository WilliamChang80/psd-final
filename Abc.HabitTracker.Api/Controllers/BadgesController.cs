using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Dto;

namespace Abc.HabitTracker.Api.Controllers
{
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly IBadgeService badgeService;
        public BadgesController(IBadgeService _badgeService)
        {
            badgeService = _badgeService;
        }

        [HttpGet("api/v1/users/{userID}/badges")]
        public ActionResult<List<BadgeResponse>> All(Guid userID)
        {
            return badgeService.GetBadgeByUserId(userID);
        }
    }
}

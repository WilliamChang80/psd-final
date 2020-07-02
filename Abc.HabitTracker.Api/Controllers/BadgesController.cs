using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Abc.HabitTracker.Api.Service;

namespace Abc.HabitTracker.Api.Controllers
{
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly IUserService userService;
        public BadgesController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet("api/v1/users/{userID}/badges")]
        public User All(Guid userID)
        {
            return userService.GetUserById(userID);
        }
    }
}

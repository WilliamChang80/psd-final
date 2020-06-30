using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Abc.HabitTracker.Api.Controllers
{
    [ApiController]
    public class BadgesController : ControllerBase
    {
        private readonly ILogger<BadgesController> _logger;

        public BadgesController(ILogger<BadgesController> logger)
        {
            _logger = logger;
        }

        [HttpGet("api/v1/users/{userID}/badges")]
        public ActionResult<IEnumerable<Badge>> All(Guid userID)
        {
            return null;
        }
    }
}

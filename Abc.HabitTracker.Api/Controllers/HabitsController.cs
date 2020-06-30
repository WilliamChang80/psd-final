﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Abc.HabitTracker.Api.Dto;

namespace Abc.HabitTracker.Api.Controllers
{
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly ILogger<HabitsController> _logger;

        public HabitsController(ILogger<HabitsController> logger)
        {
            _logger = logger;
        }

        [HttpGet("api/v1/users/{userID}/habits")]
        public ActionResult<IEnumerable<Habit>> All(Guid userID)
        {
            return null;
        }

        [HttpGet("api/v1/users/{userID}/habits/{id}")]
        public ActionResult<Habit> Get(Guid userID, Guid id)
        {
            return null;
        }

        [HttpPost("api/v1/users/{userID}/habits")]
        public ActionResult<Habit> AddNewHabit(Guid userID, [FromBody] HabitDto data)
        {
            return null;
        }

        [HttpPut("api/v1/users/{userID}/habits/{id}")]
        public ActionResult<Habit> UpdateHabit(Guid userID, Guid id, [FromBody] HabitDto data)
        {
            return null;
        }

        [HttpDelete("api/v1/users/{userID}/habits/{id}")]
        public ActionResult<Habit> DeleteHabit(Guid userID, Guid id)
        {
            return null;
        }

        [HttpPost("api/v1/users/{userID}/habits/{id}/logs")]
        public ActionResult<Habit> Log(Guid userID, Guid id)
        {
            return null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;

namespace Abc.HabitTracker.Api.Controllers
{
    [ApiController]
    public class HabitsController : ControllerBase
    {
        private readonly IHabitService habitService;
        public HabitsController(IHabitService _habitService)
        {
            habitService = _habitService;
        }

        [HttpGet("api/v1/users/{userID}/habits")]
        public ActionResult<List<HabitResponse>> All(Guid userID)
        {
            return habitService.GetHabitByUserId(userID);
        }

        [HttpGet("api/v1/users/{userID}/habits/{id}")]
        public ActionResult<HabitResponse> Get(Guid userID, Guid id)
        {
            return habitService.GetHabitById(userID, id);
        }

        [HttpPost("api/v1/users/{userID}/habits")]
        public ActionResult<HabitResponse> AddNewHabit(Guid userID, [FromBody] HabitRequest data)
        {
            return habitService.CreateHabit(data, userID);
        }

        [HttpPut("api/v1/users/{userID}/habits/{id}")]
        public ActionResult<HabitResponse> UpdateHabit(Guid userID, Guid id, [FromBody] HabitRequest data)
        {
            return habitService.UpdateHabit(userID, id, data);
        }

        [HttpDelete("api/v1/users/{userID}/habits/{id}")]
        public ActionResult<HabitResponse> DeleteHabit(Guid userId, Guid id)
        {
            return habitService.DeleteHabit(userId, id);
        }

        [HttpPost("api/v1/users/{userID}/habits/{id}/logs")]
        public ActionResult<HabitResponse> Log(Guid userID, Guid id)
        {
            return habitService.CreateHabitLog(userID, id);
        }
    }
}

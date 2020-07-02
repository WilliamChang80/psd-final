using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;

namespace Abc.HabitTracker.Api.Service
{
    public interface IUserService
    {
        User GetUserById(Guid UserId);
    }
}
using Abc.HabitTracker.Api.Dto;
using System;

namespace Abc.HabitTracker.Api.Repository
{
    public interface IUserRepository
    {
        User GetUserById(Guid UserId);

    }
}
using System;
using Abc.HabitTracker.Api.Dto;
using Abc.HabitTracker.Api.Service;
using Abc.HabitTracker.Api.Repository;

namespace Abc.HabitTracker.Api.Service.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;

        public UserService(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        public User GetUserById(Guid UserId)
        {
            return userRepository.GetUserById(UserId);
        }
    }
}
using Abc.HabitTracker.Api.Repository;
using System;
using Abc.HabitTracker.Api.Entity;

namespace Abc.HabitTracker.Api.Repository.Impl
{
    public class UserRepositoryPostgre : IUserRepository
    {
        private ApplicationDbContext applicationDb;

        public UserRepositoryPostgre(ApplicationDbContext _applicationDb)
        {
            applicationDb = _applicationDb;
        }

        public User GetUserById(Guid UserId)
        {
            return applicationDb.Users.Find(UserId);
        }
    }
}
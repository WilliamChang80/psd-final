using Abc.HabitTracker.Api.Dto;

namespace Abc.HabitTracker.Api.Repository
{
    public interface IUserRepository
    {
        User getUserById(Guid UserId);

    }
}
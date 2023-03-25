using Onix.Application.Utilities.Result;
using Onix.Domain.Entities;

namespace Onix.Application.Repositories.UserRepositories
{
    public interface IUserReadRepository : IReadRepository<User>
    {
        Task<IDataResult<User>> GetUserByUsernameOrEmailAsync(string usernameOrEmail);
        Guid GetCurrentUserIdFromContext();
    }
}

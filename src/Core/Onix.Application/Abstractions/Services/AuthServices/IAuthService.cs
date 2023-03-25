using Onix.Application.Utilities.Result;
using Onix.Application.ViewModels.Authentication;

namespace Onix.Application.Abstractions.Services.AuthServices
{
    public interface IAuthService
    {
        Task<IDataResult<LoginVM>> LoginAsync(string usernameOrEmail, string password);
    }
}

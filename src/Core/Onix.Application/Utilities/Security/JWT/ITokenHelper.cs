using Onix.Domain.Entities;

namespace Onix.Application.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user);
    }
}
using MediatR;
using Onix.Application.Utilities.Result;

namespace Onix.Application.Features.Commands.Authentication.Logout
{
    public class LogoutCommandRequest : IRequest<Result>
    {
        public string Username { get; set; }
        public Guid CompanyId { get; set; }
    }
}

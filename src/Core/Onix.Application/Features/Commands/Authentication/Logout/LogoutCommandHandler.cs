using MediatR;
using Onix.Application.Utilities.Result;

namespace Onix.Application.Features.Commands.Authentication.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommandRequest, Result>
    {
        public async Task<Result> Handle(LogoutCommandRequest request, CancellationToken cancellationToken)
        {
            return new SuccessResult();
        }
    }
}

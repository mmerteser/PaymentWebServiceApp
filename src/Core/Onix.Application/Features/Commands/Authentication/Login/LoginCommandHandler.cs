using MediatR;
using Onix.Application.Abstractions.Services.AuthServices;
using Onix.Application.Utilities.Result;
using Onix.Application.ViewModels.Authentication;

namespace Onix.Application.Features.Commands.Authentication.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommandRequest, Result>
    {
        private readonly IAuthService _authService;

        public LoginCommandHandler(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Result> Handle(LoginCommandRequest request, CancellationToken cancellationToken)
        {
            var result = await _authService.LoginAsync(request.UsernameOrEmail, request.Password);

            if (!result.Success)
                return new ErrorDataResult<LoginVM>(result.Data, result.Message);

            return new SuccessDataResult<LoginVM>(result.Data, result.Message);

        }
    }
}

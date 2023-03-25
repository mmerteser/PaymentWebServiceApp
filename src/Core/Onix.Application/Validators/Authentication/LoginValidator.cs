using FluentValidation;
using Onix.Application.Constants;
using Onix.Application.Features.Commands.Authentication.Login;

namespace Onix.Application.Validators.Authentication
{
    public class LoginValidator : AbstractValidator<LoginCommandRequest>
    {
        public LoginValidator()
        {
            RuleFor(i => i.UsernameOrEmail)
                .NotEmpty()
                    .WithMessage(ValidationMessages.UsernameCannotBeEmpty)
                .NotNull()
                    .WithMessage(ValidationMessages.UsernameCannotBeEmpty);

            RuleFor(i => i.Password)
                .NotEmpty()
                    .WithMessage(ValidationMessages.PasswordCannotBeEmpty)
                .NotNull()
                    .WithMessage(ValidationMessages.PasswordCannotBeEmpty);
        }
    }
}

using MediatR;
using Onix.Application.Utilities.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Application.Features.Commands.Authentication.Login
{
    public class LoginCommandRequest : IRequest<Result>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }
    }
}

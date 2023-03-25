using AutoMapper;
using Microsoft.Extensions.Logging;
using Onix.Application.Abstractions.Services.AuthServices;
using Onix.Application.Constants;
using Onix.Application.Repositories.UserRepositories;
using Onix.Application.Utilities.Result;
using Onix.Application.Utilities.Security.Hashing;
using Onix.Application.Utilities.Security.JWT;
using Onix.Application.ViewModels.Authentication;

namespace Onix.Persistence.Services.AuthServices
{
    public class AuthService : IAuthService
    {
        private readonly IUserReadRepository _userReadRepository;
        private readonly ITokenHelper _tokenHelper;
        private readonly IMapper _mapper;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IUserReadRepository userReadRepository, ITokenHelper tokenHelper, IMapper mapper, ILogger<AuthService> logger)
        {
            _userReadRepository = userReadRepository;
            _tokenHelper = tokenHelper;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<IDataResult<LoginVM>> LoginAsync(string usernameOrEmail, string password)
        {
            try
            {
                var user = await _userReadRepository.GetUserByUsernameOrEmailAsync(usernameOrEmail);

                if (!user.Success)
                    return new ErrorDataResult<LoginVM>(new LoginVM(), user.Message);

                bool isVerify = HashingHelper.VerifyPasswordHash(password, user.Data.PasswordHash, user.Data.PasswordSalt);

                if (!isVerify)
                    return new ErrorDataResult<LoginVM>(new LoginVM(), Message.WrongPassword);

                var token = _tokenHelper.CreateToken(user.Data);

                var loginVM = new LoginVM
                {
                    FirstLastName = user.Data.FirstLastName,
                    Token = token,
                };

                var userMenus = _mapper.Map(user.Data.UserMenus.Select(i => i.ApplicationMenu), loginVM.UserMenus);

                _mapper.Map(user.Data.CompanyInformation, loginVM.CompanyInformation);

                loginVM.UserMenus = userMenus;

                return new SuccessDataResult<LoginVM>(loginVM, Message.Success);
            }
            catch (Exception ex)
            {
                _logger.LogCritical(ex, $"{nameof(AuthService)} {nameof(LoginAsync)} - {ex.Message}");
                return new ErrorDataResult<LoginVM>(new LoginVM(), Message.Error);
            }
        }
    }
}

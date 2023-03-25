using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Onix.Application.Constants;
using Onix.Application.Repositories.UserRepositories;
using Onix.Application.Utilities.Result;
using Onix.Domain.Entities;
using Onix.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Persistence.Repositories.UserRepositories
{
    public class UserReadRepository : ReadRepository<User>, IUserReadRepository
    {
        private readonly OnixContext context;
        private readonly ILogger<UserReadRepository> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserReadRepository(OnixContext context, IHttpContextAccessor httpContextAccessor, ILogger<UserReadRepository> logger) : base(context)
        {
            this.context = context;
            _httpContextAccessor = httpContextAccessor;
            _logger = logger;
        }

        public Guid GetCurrentUserIdFromContext()
        {
            string userId = _httpContextAccessor.HttpContext.User.FindFirstValue(CustomClaimTypes.UserId);

            if(!String.IsNullOrEmpty(userId))
                return Guid.Parse(userId);
            
            return Guid.Empty;
        }

        public async Task<IDataResult<User>> GetUserByUsernameOrEmailAsync(string usernameOrEmail)
        {
            _logger.LogInformation("GetUserByUsernameOrEmailAsync running for {sernameOrEmail}", usernameOrEmail);

            var user = await Table.Include(i => i.CompanyInformation)
                                                      .Include(
                                                                menus => menus.UserMenus
                                                                .Where(m => m.Permission)
                                                                )
                                                      .ThenInclude(i => i.ApplicationMenu)
                                                      .FirstOrDefaultAsync(i => i.Username.Equals(usernameOrEmail));

            if (user is null)
                return new ErrorDataResult<User>(new User(), Message.UserNotFound);
            else
            {
                if (user.IsBlocked)
                    return new ErrorDataResult<User>(new User(), Message.Blocked);
                else
                    return new SuccessDataResult<User>(user, Message.Success);
            }
        }
    }
}

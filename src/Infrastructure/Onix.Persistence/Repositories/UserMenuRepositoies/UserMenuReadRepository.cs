using Onix.Application.Repositories.UserMenuRepositories;
using Onix.Domain.Entities;
using Onix.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Persistence.Repositories.UserMenuRepositoies
{
    public class UserMenuReadRepository : ReadRepository<UserMenu>, IUserMenuReadRepository
    {
        public UserMenuReadRepository(OnixContext context) : base(context)
        {
        }
    }
}

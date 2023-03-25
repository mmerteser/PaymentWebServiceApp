using Onix.Application.Repositories.UserRepositories;
using Onix.Domain.Entities;
using Onix.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Persistence.Repositories.UserRepositories
{
    public class UserWriteRepository : WriteRepository<User>, IUserWriteRepository
    {
        public UserWriteRepository(OnixContext context) : base(context)
        {
        }
    }
}

using Onix.Application.Repositories.UserErpInformationRepositories;
using Onix.Domain.Entities;
using Onix.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Persistence.Repositories.UserErpInformationRepositories
{
    public class UserErpInformationReadRepository : ReadRepository<UserErpInformation>, IUserErpInformationReadRepository
    {
        public UserErpInformationReadRepository(OnixContext context) : base(context)
        {
        }
    }
}

using Onix.Application.Repositories.UserErpInformationRepositories;
using Onix.Domain.Entities;
using Onix.Persistence.Context;

namespace Onix.Persistence.Repositories.UserErpInformationRepositories
{
    public class UserErpInformationWriteRepository : WriteRepository<UserErpInformation>, IUserErpInformationWriteRepository
    {
        public UserErpInformationWriteRepository(OnixContext context) : base(context)
        {
        }
    }
}

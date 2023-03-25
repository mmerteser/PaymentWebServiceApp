using Onix.Application.Repositories.CompanyInformationRepositories;
using Onix.Domain.Entities;
using Onix.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Persistence.Repositories.CompanyInfornationRepositories
{
    internal class CompanyInformationReadRepository : ReadRepository<CompanyInformation>, ICompanyInformationReadRepository
    {
        public CompanyInformationReadRepository(OnixContext context) : base(context)
        {
        }
    }
}

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
    public class CompanyInformationWriteRepository : WriteRepository<CompanyInformation>, ICompanyInformationWriteRepository
    {
        public CompanyInformationWriteRepository(OnixContext context) : base(context)
        {
        }
    }
}

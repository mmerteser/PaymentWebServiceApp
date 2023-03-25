using Onix.Application.DTOs.CompanyDTOs;
using Onix.Application.Enums;
using Onix.Application.Utilities.Result;
using Onix.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Application.Abstractions.Services.CompanyServices
{
    public interface ICompanyService
    {
        Task<IDataResult<CompanyIntegrationInformationDTO>> GetCompanyIntegrationInfo();
        Task<IDataResult<UserErpInformation>> GetUserErpInfo    ();
        IDataResult<AuthenticationType> GetAuthenticationType(string authType);
        IDataResult<IntegratedApplication> GetIntegratedApplication(string integratedApp);
        IDataResult<IntegratedApplicationType> GetIntegratedApplicationType(string integratedAppType);
    }
}

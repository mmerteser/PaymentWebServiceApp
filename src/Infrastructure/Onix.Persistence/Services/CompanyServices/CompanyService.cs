using Microsoft.Extensions.Logging;
using Onix.Application.Abstractions.Services.CompanyServices;
using Onix.Application.Common.Result;
using Onix.Application.DTOs.CompanyDTOs;
using Onix.Application.Enums;
using Onix.Application.Exceptions;
using Onix.Application.Repositories.CompanyInformationRepositories;
using Onix.Application.Repositories.UserRepositories;
using Onix.Application.Utilities;
using Onix.Application.Utilities.Result;
using Onix.Domain.Entities;
using System.Globalization;

namespace Onix.Persistence.Services.CompanyServices
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyInformationReadRepository _companyInformationReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly ILogger<CompanyService> _logger;
        public CompanyService(ICompanyInformationReadRepository companyInformationReadRepository, IUserReadRepository userReadRepository, ILogger<CompanyService> logger)
        {
            _companyInformationReadRepository = companyInformationReadRepository;
            _userReadRepository = userReadRepository;
            _logger = logger;
        }

        public async Task<IDataResult<CompanyIntegrationInformationDTO>> GetCompanyIntegrationInfo()
        {
            try
            {
                _logger.LogInformation("GetCompanyIntegrationInfo runnig");

                Guid userId = _userReadRepository.GetCurrentUserIdFromContext();

                var user = await _userReadRepository.GetByIdAsync(userId, noTracking: false, includes: u => u.UserErpInformation);

                if (user is null)
                {
                    _logger.LogError("{userId} id'li kullanıcı bulunamadı", userId);
                    throw new UserNotFoundException();
                }

                var company = await _companyInformationReadRepository.GetByIdAsync(user.CompanyId);

                var control = BusinessRules.RunBusiness(CheckIfIntegrationRequirments(company)
                                                        , GetAuthenticationType(company.AuthenticationType)
                                                        , GetIntegratedApplication(company.ApplicationName)
                                                        , GetIntegratedApplicationType(company.Type));

                if (control is not null)
                    return new ErrorDataResult<CompanyIntegrationInformationDTO>(new CompanyIntegrationInformationDTO(), control.Message);

                var resultModel = new CompanyIntegrationInformationDTO
                {
                    Password = company.Password,
                    SecurityKey = company.SecurityKey,
                    ServiceUrl = SetServiceUrl(company.ServiceUrl),
                    Username = company.Username,
                    LangCode = user.LangCode,
                    AuthenticationType = GetAuthenticationType(company.AuthenticationType).Data,
                    IntegratedApplication = GetIntegratedApplication(company.ApplicationName).Data,
                    IntegratedApplicationType = GetIntegratedApplicationType(company.Type).Data,

                };

                return new SuccessDataResult<CompanyIntegrationInformationDTO>(resultModel);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<IDataResult<UserErpInformation>> GetUserErpInfo()
        {
            Guid userId = _userReadRepository.GetCurrentUserIdFromContext();

            var user = await _userReadRepository.GetByIdAsync(userId, noTracking: false, includes: u => u.UserErpInformation);

            ArgumentNullException.ThrowIfNull(user.UserErpInformation, nameof(user.UserErpInformation));

            ArgumentNullException.ThrowIfNullOrEmpty(user.UserErpInformation.ErpUsername, nameof(user.UserErpInformation.ErpUsername));
            ArgumentNullException.ThrowIfNullOrEmpty(user.UserErpInformation.ErpPassword, nameof(user.UserErpInformation.ErpPassword));
            ArgumentNullException.ThrowIfNullOrEmpty(user.UserErpInformation.ErpUserGroupCode, nameof(user.UserErpInformation.ErpUserGroupCode));

            return new SuccessDataResult<UserErpInformation>(user.UserErpInformation);
        }

        private string SetServiceUrl(string serviceUrl)
        {
            if (!serviceUrl.Last().Equals('/'))
                return serviceUrl += '/';

            return serviceUrl;
        }

        public IDataResult<AuthenticationType> GetAuthenticationType(string authenticationType)
        {
            try
            {
                var value = Enum.Parse<AuthenticationType>(authenticationType);

                return new SuccessDataResult<AuthenticationType>(value);
            }
            catch (Exception)
            {
                return new ErrorDataResult<AuthenticationType>(AuthenticationType.None, "Hatalı authentication type");
            }
        }

        public IDataResult<IntegratedApplication> GetIntegratedApplication(string integratedApp)
        {
            try
            {
                var value = Enum.Parse<IntegratedApplication>(integratedApp);

                return new SuccessDataResult<IntegratedApplication>(value);
            }
            catch (Exception)
            {
                return new ErrorDataResult<IntegratedApplication>(IntegratedApplication.None, "Şirket tablosunda hatalı uygulama kodu!");
            }
        }

        public IDataResult<IntegratedApplicationType> GetIntegratedApplicationType(string integratedAppType)
        {
            try
            {
                var value = Enum.Parse<IntegratedApplicationType>(integratedAppType);

                return new SuccessDataResult<IntegratedApplicationType>(value);
            }
            catch (Exception)
            {
                string message = "Şirket tablosunda hatalı uygulama tipi kodu!";
                _logger.LogError(nameof(GetIntegratedApplicationType) + "Error" + message);
                return new ErrorDataResult<IntegratedApplicationType>(IntegratedApplicationType.None, message);
            }
        }

        private IResult CheckIfIntegrationRequirments(CompanyInformation company)
        {
            try
            {
                ArgumentNullException.ThrowIfNullOrEmpty(company.ApplicationName, nameof(company.ApplicationName));
                ArgumentNullException.ThrowIfNullOrEmpty(company.AuthenticationType, nameof(company.AuthenticationType));

                return new SuccessResult();
            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex.Message} boş olamaz");
                return new ErrorResult(ex.Message);
            }
        }

    }
}

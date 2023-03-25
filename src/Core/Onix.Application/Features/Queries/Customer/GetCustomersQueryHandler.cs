using MediatR;
using Onix.Application.Abstractions;
using Onix.Application.Abstractions.Services.CompanyServices;
using Onix.Application.Utilities.Result;

namespace Onix.Application.Features.Queries.Customer
{
    public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQueryRequest, Result>
    {
        private readonly IIntegratedApplicationFactory _integratedApplicationFactory;
        private readonly ICompanyService _companyService;
        public GetCustomersQueryHandler(IIntegratedApplicationFactory integratedApplicationFactory
            , ICompanyService companyService)
        {
            _integratedApplicationFactory = integratedApplicationFactory;
            _companyService = companyService;
        }
        public async Task<Result> Handle(GetCustomersQueryRequest request, CancellationToken cancellationToken)
        {
            var companyIntegration = await _companyService.GetCompanyIntegrationInfo();

            if (!companyIntegration.Success)
                return new ErrorResult(companyIntegration.Message);

            var result = await _integratedApplicationFactory.GetApplicationService(companyIntegration.Data.IntegratedApplication)
                            .GetCustomersAsync(request.SearchKey);

            return new SuccessDataResult<IEnumerable<DTOs.CustomerDTOs.Customer>>(result);
        }
    }
}

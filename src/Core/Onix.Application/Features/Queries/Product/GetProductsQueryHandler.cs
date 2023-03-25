using MediatR;
using Microsoft.Extensions.Logging;
using Onix.Application.Abstractions;
using Onix.Application.Abstractions.Services.CompanyServices;
using Onix.Application.Utilities.Result;

namespace Onix.Application.Features.Queries.Product
{
    public class GetProductsQueryHandler : IRequestHandler<GetProductsQueryRequest, Result>
    {
        private readonly IIntegratedApplicationFactory _integratedApplicationFactory;
        private readonly ICompanyService _companyService;
        private readonly ILogger<GetProductsQueryHandler> _logger;
        public GetProductsQueryHandler(IIntegratedApplicationFactory integratedApplicationFactory, ICompanyService companyService, ILogger<GetProductsQueryHandler> logger)
        {
            _integratedApplicationFactory = integratedApplicationFactory;
            _companyService = companyService;
            _logger = logger;
        }

        async Task<Result> IRequestHandler<GetProductsQueryRequest, Result>.Handle(GetProductsQueryRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("GetProductQueryHandler running");

            var companyIntegration = await _companyService.GetCompanyIntegrationInfo();

            if (!companyIntegration.Success)
                return new ErrorResult(companyIntegration.Message);

            var result = await _integratedApplicationFactory.GetApplicationService(companyIntegration.Data.IntegratedApplication)
                            .GetProductsAsync(request.SearchKey);

            return new SuccessDataResult<IEnumerable<DTOs.ProductDTOs.Product>>(result);
        }
    }
}

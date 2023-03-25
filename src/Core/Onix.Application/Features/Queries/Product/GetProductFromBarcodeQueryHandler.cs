using MediatR;
using Onix.Application.Abstractions;
using Onix.Application.Abstractions.Services.CompanyServices;
using Onix.Application.Utilities.Result;

namespace Onix.Application.Features.Queries.Product
{
    public class GetProductFromBarcodeQueryHandler : IRequestHandler<GetProductFromBarcodeQueryRequest, Result>
    {
        private readonly IIntegratedApplicationFactory _integratedApplicationFactory;
        private readonly ICompanyService _companyService;
        public GetProductFromBarcodeQueryHandler(IIntegratedApplicationFactory integratedApplicationFactory
            , ICompanyService companyService)
        {
            _integratedApplicationFactory = integratedApplicationFactory;
            _companyService = companyService;
        }
        async Task<Result> IRequestHandler<GetProductFromBarcodeQueryRequest, Result>.Handle(GetProductFromBarcodeQueryRequest request, CancellationToken cancellationToken)
        {
            var companyIntegration = await _companyService.GetCompanyIntegrationInfo();

            if (!companyIntegration.Success)
                return new ErrorResult(companyIntegration.Message);

            var result = await _integratedApplicationFactory.GetApplicationService(companyIntegration.Data.IntegratedApplication)
                            .GetProductsByBarcodeAsync(request.Barcode);

            return new SuccessDataResult<IEnumerable<DTOs.ProductDTOs.Product>>(result);
        }
    }
}

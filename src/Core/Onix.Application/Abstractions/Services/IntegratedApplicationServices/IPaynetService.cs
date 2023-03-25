using Onix.Common.IntegratedApplications.Models.Paynet.ResponseModels;

namespace Onix.Application.Abstractions.Services.IntegratedApplicationServices
{
    public interface IPaynetService
    {
        Task<string> GetTokenAsync();
        Task<PaynetInitSaleTransResponseModel> InitializeSaleTransactionAsync();
    }
}

using Newtonsoft.Json;
using Onix.Application.Abstractions.Services.IntegratedApplicationServices;
using Onix.Application.Utilities.HttpService;
using Onix.Common.IntegratedApplications.Models.Paynet.RequestModels;
using Onix.Common.IntegratedApplications.Models.Paynet.ResponseModels;

namespace Onix.Integration.PaymentServices.Paynet
{
    public class PaynetService : IPaynetService
    {
        private readonly IHttpService _httpService;
        public PaynetService(IHttpService httpService)
        {
            _httpService = httpService;
        }

        public async Task<string> GetTokenAsync()
        {
            string url = "https://pts-api.paynet.com.tr/v1/agent/get_auth_key";

            var request = new
            {
                agent_id = "agent_id",
                user_id = "user_id"
            };

            var response = await _httpService.PostAsync<string>(url, request
                        , authentication: new HttpAuthentication(Application.Enums.AuthorizationScheme.Basic, "secret_key"));

            var responseStr = JsonConvert.DeserializeObject<PaynetTokenResponseModel>(response.Data);
            return responseStr.SessionKey;
        }

        public async Task<PaynetInitSaleTransResponseModel> InitializeSaleTransactionAsync()
        {

            string token = await GetTokenAsync();

            string url = "https://pts-api.paynet.com.tr/v1/softpos/init_sale_transaction";

            var request = new PaynetInitSaleTransRequestModel
            {
                Amount = 100,
                AddCommission = true,
                Instalment = 0,
                CardHolderPhone = "5342299386",
                CardHolderMail = "merteser@outlook.com",
                Description = string.Empty,
                ReferenceNo = string.Empty,
                SelectedAgentId = string.Empty,
                CallbackUrl = string.Empty,
            };

            var headers = new Dictionary<string, IEnumerable<string>>();
            headers.Add("PaynetMobile", new List<string> { "1" });

            var response = await _httpService.PostAsync<PaynetInitSaleTransResponseModel>(url, request
                        , customHeaders: headers
                        , authentication: new HttpAuthentication(Application.Enums.AuthorizationScheme.Basic, token));

            return response.Data;
        }
    }
}

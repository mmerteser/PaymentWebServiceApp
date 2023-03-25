using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Onix.Application.Abstractions.Services.CompanyServices;
using Onix.Application.Abstractions.Services.IntegratedApplicationServices;
using Onix.Application.DTOs.CustomerDTOs;
using Onix.Application.DTOs.ProductDTOs;
using Onix.Application.Repositories.UserErpInformationRepositories;
using Onix.Application.Repositories.UserRepositories;
using Onix.Application.Utilities.Helpers;
using Onix.Application.Utilities.HttpService;
using Onix.Application.Utilities.Result;
using Onix.Common.IntegratedApplications.Models.NebimV3.RequestModels;
using Onix.Common.IntegratedApplications.Models.NebimV3.ResponseModels;

namespace Onix.Integration.NebimV3
{
    public class NebimV3Service : INebimV3Service
    {
        private readonly IHttpService _httpService;
        private readonly ICompanyService _companyService;
        private readonly IUserErpInformationReadRepository _userErpInformationReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly ILogger<NebimV3Service> _logger;
        private readonly IMemoryCache _memoryCache;
        private static string _token;
        private MemoryCacheEntryOptions memoryCacheEntryOptions;
        public NebimV3Service(IHttpService httpService
            , ICompanyService companyService
            , IUserErpInformationReadRepository userErpInformationReadRepository
            , IUserReadRepository userReadRepository
            , ILogger<NebimV3Service> logger
            , IMemoryCache memoryCache)
        {
            _httpService = httpService;
            _companyService = companyService;
            _userErpInformationReadRepository = userErpInformationReadRepository;
            _userReadRepository = userReadRepository;
            _logger = logger;
            _memoryCache = memoryCache;
            memoryCacheEntryOptions = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTimeOffset.UtcNow.AddMinutes(10),
                SlidingExpiration = TimeSpan.FromMinutes(5)
            };
        }

        public async Task<IDataResult<NebimV3ConnectResponse>> Connect()
        {
            var companyResult = await _companyService.GetCompanyIntegrationInfo();

            if (!companyResult.Success)
                throw new Exception(companyResult.Message);

            var erpInfoResult = await _companyService.GetUserErpInfo();

            var connectModel = new NebimV3ConnectRequest
            {
                Password = erpInfoResult.Data.ErpPassword,
                UserGroupCode = erpInfoResult.Data.ErpUserGroupCode,
                UserName = erpInfoResult.Data.ErpUsername
            };

            var json = JsonConvert.SerializeObject(connectModel);

            string url = companyResult.Data.ServiceUrl + "IntegratorService/Connect?" + json.ToQuery();

            var result = await _httpService.GetAsync<NebimV3ConnectResponse>(url);

            _token = result.Data.Token;

            return result;
        }
        public async Task<IEnumerable<Customer>> GetCustomersAsync(string searchKey)
        {
            if (string.IsNullOrEmpty(_token))
                _ = await Connect();

            var companyResult = await _companyService.GetCompanyIntegrationInfo();

            if (!companyResult.Success)
                throw new Exception(companyResult.Message);

            if (_memoryCache.TryGetValue<IEnumerable<Customer>>(searchKey, out IEnumerable<Customer> cacheCustomers))
                return cacheCustomers;

            var model = new NebimV3RunProcModel
            {
                ProcName = "usp_ONIX_GetCustomer",
                Parameters = {
                    new NebimV3RunProcModel.Parameter { Name = "LangCode", Value = companyResult.Data.LangCode},
                    new NebimV3RunProcModel.Parameter { Name = "SearchKey", Value = searchKey},
                }
            };

            string @url = companyResult.Data.ServiceUrl + "IntegratorService/RunProc/" + _token;

            var result = await _httpService.PostAsync<string>(@url, model);

            if (result.Data.ToLower().Contains("exception"))
            {
                _logger.LogCritical($"Get customer with error: {result.Data}");
                return Enumerable.Empty<Customer>();
            }

            var customers = JsonConvert.DeserializeObject<IEnumerable<Customer>>(result.Data);

            if (customers.Any())
                _memoryCache.Set<IEnumerable<Customer>>(searchKey, customers);

            return customers;
        }

        public async Task<IEnumerable<Product>> GetProductsAsync(string searchKey)
        {
            if (string.IsNullOrEmpty(_token))
                _ = await Connect();

            var companyResult = await _companyService.GetCompanyIntegrationInfo();

            if (!companyResult.Success)
                throw new Exception(companyResult.Message);

            if (_memoryCache.TryGetValue<IEnumerable<Product>>(searchKey, out IEnumerable<Product> cacheProducts))
                return cacheProducts;

            var model = new NebimV3RunProcModel
            {
                ProcName = "usp_ONIX_GetProduct",
                Parameters = {
                    new NebimV3RunProcModel.Parameter { Name = "LangCode", Value = companyResult.Data.LangCode},
                    new NebimV3RunProcModel.Parameter { Name = "SearchKey", Value = searchKey},
                }
            };

            string @url = companyResult.Data.ServiceUrl + "IntegratorService/RunProc/" + _token;

            var result = await _httpService.PostAsync<string>(@url, model);

            if (result.Data.ToLower().Contains("exception"))
            {
                _logger.LogCritical($"Get products with error: {result.Data}");
                return Enumerable.Empty<Product>();
            }

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result.Data);

            if (products.Any())
                _memoryCache.Set<IEnumerable<Product>>(searchKey, products);

            return products;
        }

        public async Task<IEnumerable<Product>> GetProductsByBarcodeAsync(string barcode)
        {
            if (string.IsNullOrEmpty(_token))
                _ = await Connect();

            var companyResult = await _companyService.GetCompanyIntegrationInfo();

            if (!companyResult.Success)
                throw new Exception(companyResult.Message);

            if (_memoryCache.TryGetValue<IEnumerable<Product>>(barcode, out IEnumerable<Product> cacheProducts))
                return cacheProducts;

            var model = new NebimV3RunProcModel
            {
                ProcName = "usp_ONIX_GetProductFromBarcode",
                Parameters = {
                    new NebimV3RunProcModel.Parameter { Name = "LangCode", Value = companyResult.Data.LangCode},
                    new NebimV3RunProcModel.Parameter { Name = "Barcode", Value = barcode},
                }
            };

            string @url = companyResult.Data.ServiceUrl + "IntegratorService/RunProc/" + _token;

            var result = await _httpService.PostAsync<string>(@url, model);

            if (result.Data.ToLower().Contains("exception"))
            {
                _logger.LogCritical($"Get product from barcode with error: {result.Data}");
                return Enumerable.Empty<Product>();
            }

            var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(result.Data);

            if (products.Any())
                _memoryCache.Set<IEnumerable<Product>>(barcode, products);

            return products;
        }
    }
}

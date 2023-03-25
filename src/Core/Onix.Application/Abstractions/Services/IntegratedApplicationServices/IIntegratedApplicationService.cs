using Onix.Application.DTOs.CustomerDTOs;
using Onix.Application.DTOs.ProductDTOs;

namespace Onix.Application.Abstractions.Services.IntegratedApplicationServices
{
    public interface IIntegratedApplicationService
    {
        Task<IEnumerable<Product>> GetProductsAsync(string searchKey);
        Task<IEnumerable<Product>> GetProductsByBarcodeAsync(string barcode);
        Task<IEnumerable<Customer>> GetCustomersAsync(string searchKey);
    }
}

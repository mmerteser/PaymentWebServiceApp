using Onix.Application.Abstractions.Services.IntegratedApplicationServices;
using Onix.Application.DTOs.CustomerDTOs;
using Onix.Application.DTOs.ProductDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Infrastructure.IntegratedApplications.NebimV3
{
    public class NebimV3Service : IIntegratedApplicationService
    {
        public Task<IEnumerable<Customer>> GetCustomersAsync(string searchKey, string langCode = "TR")
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsAsync(string searchKey, string langCode = "TR")
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByBarcodeAsync(string barcode, string langCode = "TR")
        {
            throw new NotImplementedException();
        }
    }
}

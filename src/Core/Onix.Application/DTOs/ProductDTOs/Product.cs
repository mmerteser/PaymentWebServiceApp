using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Application.DTOs.ProductDTOs
{
    public class Product
    {
        public string Id { get; set; }
        public string Sku { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string ColorCode { get; set; }
        public string ColorName { get; set; }
        public string Dim1 { get; set; }
        public string Dim2 { get; set; }
        public string Dim3 { get; set; }
        public string Barcode { get; set; }
        public decimal Price1 { get; set; }
        public decimal Price2 { get; set; }
        public string VatRate { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Application.DTOs.CustomerDTOs
{
    public class Customer
    {
        public string Id { get; set; }
        public string CustomerType { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string IdentityNumber { get; set; }
        public string TaxNumber { get; set; }
        public string Gender { get; set; }
        public string CurrencyCode { get; set; }
        public string Attribute1 { get; set; }
        public string Attribute2 { get; set; }
        public string Attribute3 { get; set; }
    }
}

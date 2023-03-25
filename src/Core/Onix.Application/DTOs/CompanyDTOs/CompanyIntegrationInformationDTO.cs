using Onix.Application.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Onix.Application.DTOs.CompanyDTOs
{
    public class CompanyIntegrationInformationDTO
    {
        public IntegratedApplication IntegratedApplication { get; set; }
        public IntegratedApplicationType IntegratedApplicationType { get; set; }
        public string ServiceUrl { get; set; }
        public AuthenticationType AuthenticationType { get; set; }
        public string SecurityKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string LangCode { get; set; }
    }
}

using Onix.Application.DTOs;
using Onix.Application.DTOs.CompanyDTOs;
using Onix.Application.Utilities.Security.JWT;
using Onix.Domain.Entities;

namespace Onix.Application.ViewModels.Authentication
{
    public class LoginVM
    {
        public string FirstLastName { get; set; }
        public AccessToken Token { get; set; } = new();
        public SimpleCompanyInformationDTO CompanyInformation { get; set; } = new();
        public IEnumerable<UserMenuDTO> UserMenus { get; set; } = new List<UserMenuDTO>();
    }
}

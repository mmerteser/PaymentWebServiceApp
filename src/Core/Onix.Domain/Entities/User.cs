using Onix.Domain.Entities.Common;

namespace Onix.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string LangCode { get; set; }
        public string FirstLastName { get; set; }
        public string Email { get; set; }
        public Guid CompanyId { get; set; }
        public bool IsBlocked { get; set; }

        public virtual UserErpInformation UserErpInformation { get; set; }
        public virtual CompanyInformation CompanyInformation { get; set; }
        public virtual IEnumerable<UserMenu> UserMenus { get; set; }

    }
}

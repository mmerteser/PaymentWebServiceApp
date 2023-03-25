using Onix.Domain.Entities.Common;

namespace Onix.Domain.Entities
{
    public class CompanyInformation : BaseEntity
    {
        public string CompanyName { get; set; }
        public string ApplicationName { get; set; }
        public string Type { get; set; }
        public string ServiceUrl { get; set; }
        public string AuthenticationType { get; set; }
        public string SecurityKey { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public virtual IEnumerable<User> Users { get; set; }
    }
}

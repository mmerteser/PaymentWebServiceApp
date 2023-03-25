using Onix.Domain.Entities.Common;

namespace Onix.Domain.Entities
{
    public class ApplicationMenu : BaseEntity
    {
        public int MenuCode { get; set; }
        public string Name { get; set; }
        public string ApplicationType { get; set; }

        public virtual ICollection<UserMenu> UserMenus { get; set; }
    }
}

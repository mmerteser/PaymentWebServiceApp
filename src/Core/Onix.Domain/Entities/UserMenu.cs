using Onix.Domain.Entities.Common;

namespace Onix.Domain.Entities
{
    public class UserMenu : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid MenuId { get; set; }
        public bool Permission { get; set; }

        public virtual User User { get; set; }
        public virtual ApplicationMenu ApplicationMenu { get; set; }
    }
}

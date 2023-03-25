using Onix.Domain.Entities.Common;

namespace Onix.Domain.Entities
{
    public class UserErpInformation : BaseEntity
    {
        public Guid UserId { get; set; }
        public string ErpUserGroupCode { get; set; }
        public string ErpUsername { get; set; }
        public string ErpPassword { get; set; }
        public string OfficeCode { get; set; }
        public string StoreCode { get; set; }
        public string WarehouseCode { get; set; }
        public int POSTerminalId { get; set; }
        public string SalepersonCode { get; set; }

        public User User { get; set; }
    }
}

using System.Collections.Generic;

namespace VRSite.Api.Context.Repository.Entities
{
    public class DbOrder
    {
        public int Id { get; set; }
        
        public int? ClientId { get; set; }
        public DbClient Client { get; set; }
        
        public int? CurrencyId { get; set; }
        public DbCurrency Currency { get; set; }
        
        public decimal Amount { get; set; }
        public bool IsPaid { get; set; }

        public List<DbLaboratoryOrderItem> LaboratoryOrderItems { get; set; } = new List<DbLaboratoryOrderItem>();
        public List<DbBundleOrderItem> BundleOrderItems { get; set; } = new List<DbBundleOrderItem>();
    }
}
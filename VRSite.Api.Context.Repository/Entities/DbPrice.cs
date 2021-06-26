namespace VRSite.Api.Context.Repository.Entities
{
    public class DbPrice
    {
        public int Id { get; set; }
        public decimal Price { get; set; }

        public int? CurrencyId { get; set; }
        public DbCurrency Currency { get; set; }

        public int? LaboratoryId { get; set; }
        public DbLaboratory Laboratory { get; set; }

        public int? BundleId { get; set; }
        public DbBundle Bundle { get; set; }
    }
}

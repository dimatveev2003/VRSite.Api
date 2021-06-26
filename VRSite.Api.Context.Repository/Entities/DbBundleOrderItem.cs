namespace VRSite.Api.Context.Repository.Entities
{
    public class DbBundleOrderItem
    {
        public int Id { get; set; }
        
        public int? OrderId { get; set; }
        public DbOrder Order { get; set; }
        
        public int? BundleId { get; set; }
        public DbBundle Bundle { get; set; }
    }
}
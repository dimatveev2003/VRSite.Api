namespace VRSite.Api.Context.Repository.Entities
{
    public class DbLaboratoryOrderItem
    {
        public int Id { get; set; }
        
        public int? OrderId { get; set; }
        public DbOrder Order { get; set; }
        
        public int? LaboratoryId { get; set; }
        public DbLaboratory Laboratory { get; set; }
    }
}
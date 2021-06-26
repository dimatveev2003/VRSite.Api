using System.Collections.Generic;

namespace VRSite.Api.Context.Repository.Entities
{
    public class DbLaboratory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public string VideoId { get; set; }
        public string FileDownloadLink { get; set; }

        public List<DbPrice> Prices { get; set; } = new List<DbPrice>();

        public int? BundleId { get; set; }
        public DbBundle Bundle { get; set; }
        
        public List<DbLaboratoryOrderItem> LaboratoryOrderItems { get; set; } = new List<DbLaboratoryOrderItem>();
    }
}

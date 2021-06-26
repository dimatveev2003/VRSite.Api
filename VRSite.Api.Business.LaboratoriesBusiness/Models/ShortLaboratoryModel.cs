using System.Collections.Generic;

namespace VRSite.Api.Business.LaboratoriesBusiness.Models
{
    public class ShortLaboratoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        
        public string VideoId { get; set; }
        
        public List<PriceModel> Prices { get; set; }
    }
}
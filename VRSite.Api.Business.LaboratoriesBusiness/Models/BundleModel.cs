using System.Collections.Generic;

namespace VRSite.Api.Business.LaboratoriesBusiness.Models
{
    public class BundleModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ShortLaboratoryModel> Laboratories { get; set; }

        public List<PriceModel> Prices { get; set; }
    }
}

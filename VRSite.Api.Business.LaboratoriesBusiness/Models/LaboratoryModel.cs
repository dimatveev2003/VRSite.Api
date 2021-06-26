using System;
using System.Collections.Generic;
using System.Text;

namespace VRSite.Api.Business.LaboratoriesBusiness.Models
{
    public class LaboratoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Section { get; set; }
        public string Description { get; set; }
        public string VideoId { get; set; }
        public string FileDownloadLink { get; set; }

        public List<PriceModel> Prices { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace VRSite.Api.Context.Repository.Entities
{
    public class DbBundle
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<DbLaboratory> Laboratories { get; set; } = new List<DbLaboratory>();

        public List<DbPrice> Prices { get; set; } = new List<DbPrice>();
        
        public List<DbBundleOrderItem> BundleOrderItems { get; set; } = new List<DbBundleOrderItem>();
    }
}

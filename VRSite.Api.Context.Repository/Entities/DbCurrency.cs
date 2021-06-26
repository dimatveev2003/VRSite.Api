using System.Collections.Generic;

namespace VRSite.Api.Context.Repository.Entities
{
    public class DbCurrency
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string CurrencySymbol { get; set; }

        public List<DbPrice> Prices { get; set; } = new List<DbPrice>();

        public List<DbOrder> Orders { get; set; } = new List<DbOrder>();
    }
}

namespace VRSite.Api.Business.LaboratoriesBusiness.Models
{
    public class PriceModel
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public CurrencyModel Currency { get; set; }
    }
}

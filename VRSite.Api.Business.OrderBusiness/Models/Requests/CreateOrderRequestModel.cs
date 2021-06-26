namespace VRSite.Api.Business.OrderBusiness.Models.Requests
{
    public class CreateOrderRequestModel
    {
        public decimal Amount { get; set; }
        public int CurrencyId { get; set; }
        public OrderItemModel[] OrderItems { get; set; }
    }
}
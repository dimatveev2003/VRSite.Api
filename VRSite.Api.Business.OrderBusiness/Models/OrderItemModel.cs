using VRSite.Api.Business.OrderBusiness.Enums;

namespace VRSite.Api.Business.OrderBusiness.Models
{
    public class OrderItemModel
    {
        public int Id { get; set; }
        public ProductType Type { get; set; }
    }
}
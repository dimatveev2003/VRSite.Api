using VRSite.Api.Business.OrderBusiness.Models.Requests;
using VRSite.Api.Context.Repository.Entities;

namespace VRSite.Api.Business.OrderBusiness.Helpers
{
    public static class OrderHelper
    {
        public static DbOrder GetDbOrder(CreateOrderRequestModel model, DbClient client, DbCurrency currency)
        {
            var result = new DbOrder
            {
                Client = client,
                Currency = currency,
                Amount = model.Amount,
                IsPaid = false
            };

            return result;
        }
    }
}
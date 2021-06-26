using System.Threading.Tasks;
using VRSite.Api.Business.OrderBusiness.Models.Requests;
using VRSite.Api.Business.OrderBusiness.Models.Responses;

namespace VRSite.Api.Business.OrderBusiness.Contracts
{
    public interface IOrderBusiness
    {
        Task<CreateOrderResponseModel> CreateOrder(CreateOrderRequestModel requestModel);
    }
}
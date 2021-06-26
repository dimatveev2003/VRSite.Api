using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VRSite.Api.Business.OrderBusiness.Contracts;
using VRSite.Api.Business.OrderBusiness.Models.Requests;
using VRSite.Api.Business.OrderBusiness.Models.Responses;

namespace VRSite.Api.Controllers
{
    [Route("api/v1/personal-area/order")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrderController : ControllerBase
    {
        private readonly IOrderBusiness _orderBusiness;

        public OrderController(IOrderBusiness orderBusiness)
        {
            _orderBusiness = orderBusiness;
        }

        [HttpPost]
        [Route("create-order")]
        [ProducesResponseType(typeof(CreateOrderResponseModel), 200)]
        public async Task<IActionResult> CreateOrderAsync(CreateOrderRequestModel model)
        {
            var result = await _orderBusiness.CreateOrder(model);

            return Ok(result);
        }
    }
}
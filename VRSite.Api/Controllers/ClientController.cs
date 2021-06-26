using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VRSite.Api.Business.ClientBusiness.Contracts;
using VRSite.Api.Business.ClientBusiness.Models.Requests;
using VRSite.Api.Business.ClientBusiness.Models.Responses;

namespace VRSite.Api.Controllers
{
    [Route("api/v1/personal-area/client")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ClientController : ControllerBase
    {
        private readonly IClientBusiness _clientBusiness;

        public ClientController(IClientBusiness clientBusiness)
        {
            _clientBusiness = clientBusiness;
        }

        [HttpPost]
        [Route("register-client")]
        [ProducesResponseType(typeof(RegisterClientResponseModel), 200)]
        [AllowAnonymous]
        public async Task<IActionResult> RegisterClientAsync([FromBody] RegisterClientRequestModel model)
        {
            var result = await _clientBusiness.RegisterClient(model);

            return Ok(result);
        }

        [HttpGet]
        [Route("login-client")]
        [ProducesResponseType(typeof(LoginClientResponseModel), 200)]
        [AllowAnonymous]
        public async Task<IActionResult> LoginClientAsync([FromQuery] LoginClientRequestModel model)
        {
            var result = await _clientBusiness.LoginClient(model);

            return Ok(result);
        }

        [HttpGet]
        [Route("client-info")]
        public async Task<IActionResult> GetClientInfoAsync()
        {
            var result = await _clientBusiness.GetClientInfo();

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(SaveClientInfoResponseModel), 200)]
        [Route("update-client-info")]
        public async Task<IActionResult> UpdateClientInfoAsync(SaveClientInfoRequestModel model)
        {
            var result = await _clientBusiness.SaveClientInfo(model);

            return Ok(result);
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(ChangePasswordResponseModel), 200)]
        [Route("change-password")]
        public async Task<IActionResult> ChangePasswordAsync(ChangePasswordRequestModel model)
        {
            var result = await _clientBusiness.ChangePassword(model);

            return Ok(result);
        }
    }
}
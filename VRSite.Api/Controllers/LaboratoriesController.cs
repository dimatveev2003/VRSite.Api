using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VRSite.Api.Business.LaboratoriesBusiness.Contracts;
using VRSite.Api.Business.LaboratoriesBusiness.Models.Responses;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace VRSite.Api.Controllers
{
    [Route("api/v1/personal-area/laboratories")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class LaboratoriesController : ControllerBase
    {
        private readonly ILaboratoriesBusiness _laboratoriesBusiness;

        public LaboratoriesController(ILaboratoriesBusiness laboratoriesBusiness)
        {
            _laboratoriesBusiness = laboratoriesBusiness;
        }

        [HttpGet]
        [Route("get-all-labs")]
        [ProducesResponseType(typeof(GetAllLabsResponseModel), 200)]
        public async Task<IActionResult> GetAllLabsAsync()
        {
            var result = await _laboratoriesBusiness.GetAllLabs();

            return Ok(result);
        }

        [HttpGet]
        [Route("get-all-bundles")]
        [ProducesResponseType(typeof(GetAllBundlesResponseModel), 200)]
        public async Task<IActionResult> GetAllBundlesAsync()
        {
            var result = await _laboratoriesBusiness.GetAllBundles();

            return Ok(result);
        }
    }
}

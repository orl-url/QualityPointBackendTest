using Microsoft.AspNetCore.Mvc;
using qualityPointBackendTest.Dto;
using qualityPointBackendTest.Services;

namespace qualityPointBackendTest.Controllers
{
    [ApiController]
    public class DaDataController(DaDataService daDataService) : ControllerBase
    {
        [HttpGet("/standardizeAddress")]
        public async Task<ActionResult<Address>> GetStandardizedAddress(string address)
        {
            var standardizedAddress = await daDataService.StandardizeAddress(address);
            return Ok(standardizedAddress);
        }
    }
}
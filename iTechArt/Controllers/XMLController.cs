using DTOs.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XMLController : ControllerBase
    {
        private readonly IXMLService _xmlService;
        public XMLController(IXMLService xmlService)
        {
            _xmlService = xmlService;
        }

        [HttpGet("export")]
        public async Task<IActionResult> ExportToXML()
        {
            await _xmlService.ExportToXML();
            return Ok();
        }
    }
}

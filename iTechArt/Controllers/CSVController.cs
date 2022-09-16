using DTOs.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class CSVController : ControllerBase
    {
        private readonly ICSVService _csvService;
        public CSVController( ICSVService csvService )
        {
            _csvService = csvService;
        }

        [HttpPost( "import" )]
        public async Task<IActionResult> ImportCSV()
        {
            await _csvService.ImportCSV();
            return Ok();
        }
    }
}

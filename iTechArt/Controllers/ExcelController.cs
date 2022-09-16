using DTOs.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly IExcelService _excelService;
        public ExcelController( IExcelService excelService )
        {
            _excelService = excelService;
        }

        [HttpPost( "import" )]
        public async Task<IActionResult> ImportExcel()
        {
            await _excelService.ImportExcelData();
            return Ok();
        }
    }
}

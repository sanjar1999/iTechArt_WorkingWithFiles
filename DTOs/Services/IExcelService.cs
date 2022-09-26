using DAL.Models;
using Microsoft.AspNetCore.Http;

namespace DTOs.Services
{
    public interface IExcelService
    {
        Task ImportExcelData(IFormFile file);
    }
}

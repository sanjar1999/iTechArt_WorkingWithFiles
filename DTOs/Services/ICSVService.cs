using Microsoft.AspNetCore.Http;

namespace DTOs.Services
{
    public interface ICSVService
    {
        Task ImportCSV(IFormFile file);
    }
}

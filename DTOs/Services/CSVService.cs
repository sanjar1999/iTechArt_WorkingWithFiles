using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
#pragma warning disable

namespace DTOs.Services
{
    public class CSVService : ICSVService
    {
        private readonly ApplicationContext _applicationContext;
        public CSVService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task ImportCSV(IFormFile file)
        {
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];

                if (extension == ".csv")
                {
                    var fileName = DateTime.Now.Ticks + extension; //Create a new Name for the file due to security reasons.
                    var pathBuilt = Path.Combine(Directory.GetCurrentDirectory(), "Uploads");

                    if (!Directory.Exists(pathBuilt))
                    {
                        Directory.CreateDirectory(pathBuilt);
                    }

                    var path = Path.Combine(Directory.GetCurrentDirectory(), "Uploads", fileName);

                    using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await file.CopyToAsync(stream);
                    }

                    var csvLines = File.ReadAllLines(path);

                    for (int i = 1; i < csvLines.Length; i++)
                    {
                        var rowData = csvLines[i].Split(',');

                        var list = new CSV
                        {
                            PersonName = rowData[0].ToString().Trim(),
                            Age = Convert.ToInt32(rowData[1]),
                            Pet1 = rowData[2].ToString().Trim(),
                            Pet1Type = rowData[3].ToString().Trim(),
                            Pet2 = rowData[4].ToString().Trim(),
                            Pet2Type = rowData[5].ToString().Trim(),
                            Pet3 = rowData[6].ToString().Trim(),
                            Pet3Type = rowData[7].ToString().Trim()
                        };

                        await _applicationContext.CSV.AddAsync(list);
                        await _applicationContext.SaveChangesAsync();
                    }
                }
                else
                {
                    throw new Exception("Select correct File!!!");
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(nameof(e));
            }
        }
    }
}

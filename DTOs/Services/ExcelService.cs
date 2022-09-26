using DAL;
using DAL.Models;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
#pragma warning disable

namespace DTOs.Services
{
    public class ExcelService : IExcelService
    {
        private readonly ApplicationContext _applicationContext;
        public ExcelService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task ImportExcelData(IFormFile file)
        {
            try
            {
                var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];

                if (extension == ".xlsx")
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

                    FileInfo fileInfo = new FileInfo(path);

                    if (fileInfo == null)
                    {
                        throw new ArgumentNullException("File not Found");
                    }

                    using (var package = new ExcelPackage(fileInfo))
                    {
                        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        var rowCount = worksheet.Dimension.Rows;

                        for (int row = 2; row <= rowCount; row++)
                        {
                            var list = new Excel
                            {
                                PersonName = worksheet.Cells[row, 1].Value.ToString().Trim(),
                                Age = Convert.ToInt32(worksheet.Cells[row, 2].Value),
                                Pet1 = worksheet.Cells[row, 3].Value.ToString().Trim(),
                                Pet1Type = worksheet.Cells[row, 4].Value.ToString().Trim(),
                                Pet2 = worksheet.Cells[row, 5].Value.ToString().Trim(),
                                Pet2Type = worksheet.Cells[row, 6].Value.ToString().Trim(),
                                Pet3 = worksheet.Cells[row, 7].Value.ToString().Trim(),
                                Pet3Type = worksheet.Cells[row, 8].Value.ToString().Trim()
                            };

                            await _applicationContext.Excel.AddAsync(list);
                            await _applicationContext.SaveChangesAsync();
                        }
                    }
                }
                else
                {
                    throw new Exception("Upload correct File!!!");
                }
            }
            catch (Exception e)
            {
                throw new ArgumentException(nameof(e));
            }
        }
    }
}

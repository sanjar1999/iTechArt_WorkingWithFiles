using DAL;
using DAL.Models;
using OfficeOpenXml;
#pragma warning disable

namespace DTOs.Services
{
    public class ExcelService : IExcelService
    {
        private readonly ApplicationContext _applicationContext;
        public ExcelService( ApplicationContext applicationContext )
        {
            _applicationContext = applicationContext;
        }

        public async Task ImportExcelData()
        {
            try
            {
                //add your filepath
                string filePath = @"C:\Users\SANJAR\Desktop\WorkingWithFiles\iTechArt\Files\Import_Template.xlsx";
                FileInfo fileInfo = new FileInfo( filePath );

                if ( fileInfo == null )
                {
                    throw new ArgumentNullException( "File not Found" );
                }


                using ( var package = new ExcelPackage( fileInfo ) )
                {
                    ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;
                    var colCount = worksheet.Dimension.Columns;

                    for ( int row = 2; row <= rowCount; row++ )
                    {
                        var list = new Excel
                        {
                            PersonName = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            Age = Convert.ToInt32( worksheet.Cells[row, 2].Value ),
                            Pet1 = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            Pet1Type = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            Pet2 = worksheet.Cells[row, 5].Value.ToString().Trim(),
                            Pet2Type = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            Pet3 = worksheet.Cells[row, 7].Value.ToString().Trim(),
                            Pet3Type = worksheet.Cells[row, 8].Value.ToString().Trim()
                        };

                        await _applicationContext.Excel.AddAsync( list );
                        await _applicationContext.SaveChangesAsync();
                    }
                }
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }
    }
}

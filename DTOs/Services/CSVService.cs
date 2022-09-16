using DAL;
using DAL.Models;
#pragma warning disable

namespace DTOs.Services
{
    public class CSVService : ICSVService
    {
        private readonly ApplicationContext _applicationContext;
        public CSVService( ApplicationContext applicationContext )
        {
            _applicationContext = applicationContext;
        }

        public async Task ImportCSV()
        {
            try
            {
                //add your filepath
                string[] csvLines = System.IO.File.ReadAllLines( @"C:\Users\SANJAR\Desktop\WorkingWithFiles\iTechArt\Files\Import_Template.csv" );

                for ( int i = 1; i < csvLines.Length; i++ )
                {
                    string[] rowData = csvLines[i].Split( ',' );

                    var list = new CSV
                    {
                        PersonName = rowData[0].ToString().Trim(),
                        Age = Convert.ToInt32( rowData[1] ),
                        Pet1 = rowData[2].ToString().Trim(),
                        Pet1Type = rowData[3].ToString().Trim(),
                        Pet2 = rowData[4].ToString().Trim(),
                        Pet2Type = rowData[5].ToString().Trim(),
                        Pet3 = rowData[6].ToString().Trim(),
                        Pet3Type = rowData[7].ToString().Trim()
                    };

                    await _applicationContext.CSV.AddAsync( list );
                    await _applicationContext.SaveChangesAsync();
                }
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }
    }
}

using DAL;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;
#pragma warning disable

namespace DTOs.Services
{
    public class XMLService : IXMLService
    {

        private readonly ApplicationContext _applicationContext;
        public XMLService( ApplicationContext applicationContext )
        {
            _applicationContext = applicationContext;
        }

        public async Task ExportToXML()
        {
            try
            {
                var list = await _applicationContext.Excel.Select( x => new Excel
                {
                    PersonName = x.PersonName,
                    Age = x.Age,
                    Pet1 = x.Pet1,
                    Pet1Type = x.Pet1Type,
                    Pet2 = x.Pet2,
                    Pet2Type = x.Pet2Type,
                    Pet3 = x.Pet3,
                    Pet3Type = x.Pet3Type
                } ).ToListAsync();

                foreach ( var item in list )
                {
                    string name = item.PersonName;
                    int age = item.Age;
                    string pet1type = item.Pet1Type;
                    string pet2type = item.Pet2Type;
                    string pet3type = item.Pet3Type;
                    string pet1 = item.Pet1;
                    string pet2 = item.Pet2;
                    string pet3 = item.Pet3;

                    XmlDocument doc = new XmlDocument();
                    doc.Load( @"C:\Users\SANJAR\Desktop\WorkingWithFiles\iTechArt\Files\Export_Template.xml" );

                    XmlNode personElement = doc.CreateElement( "person" );
                    XmlNode petsElement = doc.CreateElement( "pets" );
                    XmlNode petElement = doc.CreateElement( "pet" );
                    XmlNode pet2Element = doc.CreateElement( "pet" );
                    XmlNode pet3Element = doc.CreateElement( "pet" );
                    XmlAttribute personAgeAttribute = doc.CreateAttribute( "age" );
                    XmlAttribute personNameAttribute = doc.CreateAttribute( "name" );
                    XmlAttribute pet1NameAttribute = doc.CreateAttribute( "name" );
                    XmlAttribute pet1TypeAttribute = doc.CreateAttribute( "type" );
                    XmlAttribute pet2NameAttribute = doc.CreateAttribute( "name" );
                    XmlAttribute pet2TypeAttribute = doc.CreateAttribute( "type" );
                    XmlAttribute pet3NameAttribute = doc.CreateAttribute( "name" );
                    XmlAttribute pet3TypeAttribute = doc.CreateAttribute( "type" );

                    personElement.AppendChild( petsElement );
                    personAgeAttribute.Value = age.ToString();
                    personNameAttribute.Value = name.ToString();
                    personElement.Attributes.Append( personAgeAttribute );
                    personElement.Attributes.Append( personNameAttribute );

                    petsElement.AppendChild( petElement );
                    pet1NameAttribute.Value = pet1.ToString();
                    pet1TypeAttribute.Value = pet1type.ToString();
                    petElement.Attributes.Append( pet1NameAttribute );
                    petElement.Attributes.Append( pet1TypeAttribute );

                    pet2NameAttribute.Value = pet2.ToString();
                    pet2TypeAttribute.Value = pet2type.ToString();

                    if ( pet2.ToString() != "-" )
                    {
                        petsElement.AppendChild( pet2Element );
                        pet2Element.Attributes.Append( pet2NameAttribute );
                        pet2Element.Attributes.Append( pet2TypeAttribute );
                    }

                    pet3NameAttribute.Value = pet3.ToString();
                    pet3TypeAttribute.Value = pet3type.ToString();

                    if ( pet3.ToString() != "-" )
                    {
                        petsElement.AppendChild( pet3Element );
                        pet3Element.Attributes.Append( pet3NameAttribute );
                        pet3Element.Attributes.Append( pet3TypeAttribute );
                    }

                    doc.DocumentElement.AppendChild( personElement );
                    doc.Save( @"C:\Users\SANJAR\Desktop\WorkingWithFiles\iTechArt\Files\Export_Template.xml" );
                }
            }
            catch ( Exception e )
            {
                throw new ArgumentException( nameof( e ) );
            }
        }

    }
}

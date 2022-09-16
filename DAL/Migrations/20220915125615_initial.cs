using Microsoft.EntityFrameworkCore.Migrations;
#pragma warning disable
#nullable disable

namespace DAL.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.CreateTable(
                name: "CSV",
                columns: table => new
                {
                    Id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    PersonName = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Age = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Pet1 = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Pet1Type = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Pet2 = table.Column<string>( type: "nvarchar(max)", nullable: true ),
                    Pet2Type = table.Column<string>( type: "nvarchar(max)", nullable: true ),
                    Pet3 = table.Column<string>( type: "nvarchar(max)", nullable: true ),
                    Pet3Type = table.Column<string>( type: "nvarchar(max)", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_CSV", x => x.Id );
                } );

            migrationBuilder.CreateTable(
                name: "Excel",
                columns: table => new
                {
                    Id = table.Column<int>( type: "int", nullable: false )
                        .Annotation( "SqlServer:Identity", "1, 1" ),
                    PersonName = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Age = table.Column<int>( type: "int", nullable: false ),
                    Pet1 = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Pet1Type = table.Column<string>( type: "nvarchar(max)", nullable: false ),
                    Pet2 = table.Column<string>( type: "nvarchar(max)", nullable: true ),
                    Pet2Type = table.Column<string>( type: "nvarchar(max)", nullable: true ),
                    Pet3 = table.Column<string>( type: "nvarchar(max)", nullable: true ),
                    Pet3Type = table.Column<string>( type: "nvarchar(max)", nullable: true )
                },
                constraints: table =>
                {
                    table.PrimaryKey( "PK_Excel", x => x.Id );
                } );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.DropTable(
                name: "CSV" );

            migrationBuilder.DropTable(
                name: "Excel" );
        }
    }
}

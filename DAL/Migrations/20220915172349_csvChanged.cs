using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class csvChanged : Migration
    {
        protected override void Up( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.AlterColumn<int>(
                name: "Age",
                table: "CSV",
                type: "int",
                nullable: false,
                oldClrType: typeof( string ),
                oldType: "nvarchar(max)" );
        }

        protected override void Down( MigrationBuilder migrationBuilder )
        {
            migrationBuilder.AlterColumn<string>(
                name: "Age",
                table: "CSV",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof( int ),
                oldType: "int" );
        }
    }
}

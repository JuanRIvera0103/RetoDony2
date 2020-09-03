using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpresaDC.Migrations
{
    public partial class Libraass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FechaInicio",
                table: "Libra",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FechaFinalizacion",
                table: "Libra",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "FechaInicio",
                table: "Libra",
                type: "nvarchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "FechaFinalizacion",
                table: "Libra",
                type: "nvarchar(12)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpresaDC.Migrations
{
    public partial class Libras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libra",
                columns: table => new
                {
                    IdLibra = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ValorLibra = table.Column<int>(nullable: false),
                    FechaInicio = table.Column<string>(type: "nvarchar(50)", nullable: true),
                   
                    FechaFinalizacion = table.Column<string>(type: "nvarchar(12)", nullable: true)
                    
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libra", x => x.IdLibra);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libra");
        }
    }
}

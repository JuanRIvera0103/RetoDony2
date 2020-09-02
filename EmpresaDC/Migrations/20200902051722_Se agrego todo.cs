using Microsoft.EntityFrameworkCore.Migrations;

namespace EmpresaDC.Migrations
{
    public partial class Seagregotodo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    NumeroCasillero = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCliente = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Correo = table.Column<string>(nullable: false),
                    DireccionEntrega = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.NumeroCasillero);
                });

            migrationBuilder.CreateTable(
                name: "estados",
                columns: table => new
                {
                    IdEstado = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreEstado = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estados", x => x.IdEstado);
                });

            migrationBuilder.CreateTable(
                name: "mercancias",
                columns: table => new
                {
                    IdTipoMercancia = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoMercancia = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mercancias", x => x.IdTipoMercancia);
                });

            migrationBuilder.CreateTable(
                name: "paquetes",
                columns: table => new
                {
                    Codigo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Peso = table.Column<float>(nullable: false),
                    CasilleroCliente = table.Column<int>(type: "int", nullable: false),
                    Estado = table.Column<int>(nullable: false),
                    Tracking = table.Column<string>(nullable: false),
                    EmpresaTransportadora = table.Column<int>(type: "int", nullable: false),
                    Tipo = table.Column<int>(nullable: false),
                    GuiaColombia = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Valor = table.Column<float>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paquetes", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "transportadoras",
                columns: table => new
                {
                    IdTransportadora = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreTransportadora = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transportadoras", x => x.IdTransportadora);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "estados");

            migrationBuilder.DropTable(
                name: "mercancias");

            migrationBuilder.DropTable(
                name: "paquetes");

            migrationBuilder.DropTable(
                name: "transportadoras");
        }
    }
}

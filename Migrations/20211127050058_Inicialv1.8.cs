using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class Inicialv18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Comentarios",
                table: "Articulos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoCompra",
                table: "Articulos",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "PrecioFinalCompra",
                table: "Articulos",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Comentarios",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "EstadoCompra",
                table: "Articulos");

            migrationBuilder.DropColumn(
                name: "PrecioFinalCompra",
                table: "Articulos");
        }
    }
}

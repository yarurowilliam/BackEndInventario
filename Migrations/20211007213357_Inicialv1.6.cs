using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class Inicialv16 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Identificacion = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Apellido = table.Column<string>(type: "varchar(50)", nullable: false),
                    Direccion = table.Column<string>(type: "varchar(50)", nullable: false),
                    Telefono = table.Column<string>(type: "varchar(10)", nullable: true),
                    Email = table.Column<string>(type: "varchar(50)", nullable: false),
                    EstadoCliente = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Identificacion);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}

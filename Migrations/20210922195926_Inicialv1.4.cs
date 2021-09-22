using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEnd.Migrations
{
    public partial class Inicialv14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Referencia = table.Column<string>(type: "varchar(20)", nullable: false),
                    Nombre = table.Column<string>(type: "varchar(50)", nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    Precio = table.Column<double>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false),
                    ProveedorNit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Referencia);
                    table.ForeignKey(
                        name: "FK_Articulos_Categorias_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "Categorias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Articulos_Proveedores_ProveedorNit",
                        column: x => x.ProveedorNit,
                        principalTable: "Proveedores",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CategoriaId",
                table: "Articulos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_ProveedorNit",
                table: "Articulos",
                column: "ProveedorNit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");
        }
    }
}

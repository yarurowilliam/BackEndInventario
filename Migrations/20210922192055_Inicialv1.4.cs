﻿using Microsoft.EntityFrameworkCore.Migrations;

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
                    CategoriaNombre = table.Column<string>(nullable: true),
                    ProveedorId = table.Column<int>(nullable: false),
                    proveedorNit = table.Column<string>(nullable: false),
                    ProveedorRazon = table.Column<string>(nullable: true)
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
                        name: "FK_Articulos_Proveedores_proveedorNit",
                        column: x => x.proveedorNit,
                        principalTable: "Proveedores",
                        principalColumn: "Nit",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_CategoriaId",
                table: "Articulos",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_Articulos_proveedorNit",
                table: "Articulos",
                column: "proveedorNit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");
        }
    }
}

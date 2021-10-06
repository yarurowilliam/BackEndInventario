﻿// <auto-generated />
using BackEnd.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEnd.Migrations
{
    [DbContext(typeof(AplicationDbContext))]
    [Migration("20211006211742_Inicialv1.5")]
    partial class Inicialv15
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEnd.Domain.Models.Articulo", b =>
                {
                    b.Property<string>("Referencia")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<double>("Precio")
                        .HasColumnType("float");

                    b.Property<string>("ProveedorNit")
                        .HasColumnType("varchar(20)");

                    b.HasKey("Referencia");

                    b.HasIndex("CategoriaId");

                    b.HasIndex("ProveedorNit");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreCategoria")
                        .IsRequired()
                        .HasColumnType("varchar(40)");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Proveedor", b =>
                {
                    b.Property<string>("Nit")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("NombreEnc")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RazonSocial")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Telefono")
                        .HasColumnType("varchar(50)");

                    b.HasKey("Nit");

                    b.ToTable("Proveedores");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<string>("RolUser")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("BackEnd.Domain.Models.Articulo", b =>
                {
                    b.HasOne("BackEnd.Domain.Models.Categoria", "categoria")
                        .WithMany()
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEnd.Domain.Models.Proveedor", "proveedor")
                        .WithMany()
                        .HasForeignKey("ProveedorNit");
                });
#pragma warning restore 612, 618
        }
    }
}

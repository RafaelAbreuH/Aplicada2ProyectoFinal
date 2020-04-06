using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplicada2ProyectoFinal.Migrations
{
    public partial class migracion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    Cedula = table.Column<string>(nullable: false),
                    Telefono = table.Column<string>(nullable: false),
                    Direccion = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoClienteId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Cobros",
                columns: table => new
                {
                    CobroId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpeñoId = table.Column<int>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    Abono = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cobros", x => x.CobroId);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuarios",
                columns: table => new
                {
                    TipoUsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuarios", x => x.TipoUsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    UsuarioId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(nullable: false),
                    Email = table.Column<string>(maxLength: 40, nullable: false),
                    Usuario = table.Column<string>(nullable: false),
                    Contraseña = table.Column<string>(nullable: false),
                    RepeatContraseña = table.Column<string>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    TipoUsuarioId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.UsuarioId);
                });

            migrationBuilder.CreateTable(
                name: "TiposClientes",
                columns: table => new
                {
                    TipoClienteId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Descripcion = table.Column<string>(nullable: false),
                    ClientesClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposClientes", x => x.TipoClienteId);

                    migrationBuilder.CreateTable(
                        name: "CobrosDetalles",
                        columns: table => new
                        {
                            Id = table.Column<int>(nullable: false)
                                .Annotation("Sqlite:Autoincrement", true),
                            EmpeñoId = table.Column<int>(nullable: false),
                            ClienteId = table.Column<int>(nullable: false),
                            NombreCliente = table.Column<string>(nullable: true),
                            FechaEmpeño = table.Column<DateTime>(nullable: false),
                            MontoTotal = table.Column<decimal>(nullable: false),
                            Abono = table.Column<decimal>(nullable: false),
                            UltimaFechadeVigencia = table.Column<DateTime>(nullable: false),
                            CobroId = table.Column<int>(nullable: true)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PK_CobrosDetalles", x => x.Id);
                            table.ForeignKey(
                                name: "FK_CobrosDetalles_Cobros_CobroId",
                                column: x => x.CobroId,
                                principalTable: "Cobros",
                                principalColumn: "CobroId",
                                onDelete: ReferentialAction.Restrict);
                        });

                    migrationBuilder.CreateTable(
                        name: "Empeños",
                        columns: table => new
                        {
                            EmpeñoId = table.Column<int>(nullable: false),
                            ClienteId = table.Column<int>(nullable: false),
                            NombredeCliente = table.Column<string>(nullable: false),
                            Fecha = table.Column<DateTime>(nullable: false),
                            MontoTotal = table.Column<decimal>(nullable: false),
                            Abono = table.Column<decimal>(nullable: false),
                            UltimaFechadeVigencia = table.Column<DateTime>(nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PK_Empeños", x => x.EmpeñoId);
                        });

                    migrationBuilder.CreateTable(
                        name: "EmpeñosDetalles",
                        columns: table => new
                        {
                            Id = table.Column<int>(nullable: false)
                                .Annotation("Sqlite:Autoincrement", true),
                            EmpeñoId = table.Column<int>(nullable: false),
                            ArticuloId = table.Column<int>(nullable: false),
                            Articulo = table.Column<string>(nullable: false),
                            Descripcion = table.Column<string>(nullable: false),
                            Cantidad = table.Column<int>(nullable: false),
                            Monto = table.Column<decimal>(nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PK_EmpeñosDetalles", x => x.Id);
                            table.ForeignKey(
                                name: "FK_EmpeñosDetalles_Empeños_EmpeñoId",
                                column: x => x.EmpeñoId,
                                principalTable: "Empeños",
                                principalColumn: "EmpeñoId",
                                onDelete: ReferentialAction.Cascade);
                        });

                    migrationBuilder.CreateTable(
                        name: "Articulos",
                        columns: table => new
                        {
                            ArticuloId = table.Column<int>(nullable: false),
                            Nombre = table.Column<string>(nullable: false),
                            CategoriaId = table.Column<int>(nullable: false),
                            Inventario = table.Column<decimal>(nullable: false),
                            Fecha = table.Column<DateTime>(nullable: false)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PK_Articulos", x => x.ArticuloId);

                        });

                    migrationBuilder.CreateTable(
                        name: "Categorias",
                        columns: table => new
                        {
                            CategoriaId = table.Column<int>(nullable: false)
                                .Annotation("Sqlite:Autoincrement", true),
                            Nombre = table.Column<string>(nullable: false),
                            ArticulosArticuloId = table.Column<int>(nullable: true)
                        },
                        constraints: table =>
                        {
                            table.PrimaryKey("PK_Categorias", x => x.CategoriaId);
                        });

                    migrationBuilder.CreateIndex(
                        name: "IX_Categorias_ArticulosArticuloId",
                        table: "Categorias",
                        column: "ArticulosArticuloId");

                    migrationBuilder.CreateIndex(
                        name: "IX_CobrosDetalles_CobroId",
                        table: "CobrosDetalles",
                        column: "CobroId");

                    migrationBuilder.CreateIndex(
                        name: "IX_EmpeñosDetalles_EmpeñoId",
                        table: "EmpeñosDetalles",
                        column: "EmpeñoId");

                    migrationBuilder.CreateIndex(
                        name: "IX_TiposClientes_ClientesClienteId",
                        table: "TiposClientes",
                        column: "ClientesClienteId");
                    ;
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorias");

            migrationBuilder.DropTable(
                name: "TiposClientes");

            migrationBuilder.DropTable(
                name: "TiposUsuarios");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Articulos");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "EmpeñosDetalles");

            migrationBuilder.DropTable(
                name: "Empeños");

            migrationBuilder.DropTable(
                name: "CobrosDetalles");

            migrationBuilder.DropTable(
                name: "Cobros");
        }
    }
}

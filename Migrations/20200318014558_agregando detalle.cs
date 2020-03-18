using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Aplicada2ProyectoFinal.Migrations
{
    public partial class agregandodetalle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "Empeños",
                columns: table => new
                {
                    EmpeñoId = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ClienteId = table.Column<int>(nullable: false),
                    NombredeCliente = table.Column<string>(nullable: true),
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
                name: "Detalles",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EmpeñoId = table.Column<int>(nullable: false),
                    ArticuloId = table.Column<int>(nullable: false),
                    Articulo = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Cantidad = table.Column<int>(nullable: false),
                    Monto = table.Column<decimal>(nullable: false),
                    EmpeñosEmpeñoId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Detalles", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Detalles_Articulos_ArticuloId",
                        column: x => x.ArticuloId,
                        principalTable: "Articulos",
                        principalColumn: "ArticuloId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Detalles_Empeños_EmpeñosEmpeñoId",
                        column: x => x.EmpeñosEmpeñoId,
                        principalTable: "Empeños",
                        principalColumn: "EmpeñoId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_ArticuloId",
                table: "Detalles",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Detalles_EmpeñosEmpeñoId",
                table: "Detalles",
                column: "EmpeñosEmpeñoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cobros");

            migrationBuilder.DropTable(
                name: "Detalles");

            migrationBuilder.DropTable(
                name: "Empeños");
        }
    }
}

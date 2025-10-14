using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PegauchoBackend.Migrations
{
    /// <inheritdoc />
    public partial class addproduc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Producciones",
                columns: table => new
                {
                    idOrdenProd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLogin = table.Column<int>(type: "int", nullable: false),
                    UsuarioidLogin = table.Column<int>(type: "int", nullable: false),
                    codProd = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    maquinaria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matPrima = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    cantidadLitros = table.Column<double>(type: "float", nullable: false),
                    prioridad = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producciones", x => x.idOrdenProd);
                    table.ForeignKey(
                        name: "FK_Producciones_Usuarios_UsuarioidLogin",
                        column: x => x.UsuarioidLogin,
                        principalTable: "Usuarios",
                        principalColumn: "idLogin",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Producciones_idOrdenProd",
                table: "Producciones",
                column: "idOrdenProd",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Producciones_UsuarioidLogin",
                table: "Producciones",
                column: "UsuarioidLogin");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producciones");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PegauchoBackend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Producciones");

            migrationBuilder.RenameColumn(
                name: "idLogin",
                table: "Usuarios",
                newName: "IdLogin");

            migrationBuilder.AlterColumn<string>(
                name: "usuario",
                table: "Usuarios",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateTable(
                name: "PanelesControl",
                columns: table => new
                {
                    IdOrdenPanel = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdLogin = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PanelesControl", x => x.IdOrdenPanel);
                    table.ForeignKey(
                        name: "FK_PanelesControl_Usuarios_IdLogin",
                        column: x => x.IdLogin,
                        principalTable: "Usuarios",
                        principalColumn: "IdLogin",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesProduccion",
                columns: table => new
                {
                    IdOrdenProd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrdenPanel = table.Column<int>(type: "int", nullable: false),
                    IdLogin = table.Column<int>(type: "int", nullable: false),
                    codProd = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maquinaProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    matPrima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    prioridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    tiempoEstimado = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesProduccion", x => x.IdOrdenProd);
                    table.ForeignKey(
                        name: "FK_OrdenesProduccion_PanelesControl_IdOrdenPanel",
                        column: x => x.IdOrdenPanel,
                        principalTable: "PanelesControl",
                        principalColumn: "IdOrdenPanel",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesProduccion_Usuarios_IdLogin",
                        column: x => x.IdLogin,
                        principalTable: "Usuarios",
                        principalColumn: "IdLogin",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenesDosificacion",
                columns: table => new
                {
                    IdOrdenDos = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdOrdenPanel = table.Column<int>(type: "int", nullable: false),
                    IdOrdenProd = table.Column<int>(type: "int", nullable: false),
                    codProd = table.Column<int>(type: "int", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    maquinaProd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    matPrima = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cantidad = table.Column<int>(type: "int", nullable: true),
                    prioridad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    costo = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    tiempoEstimado = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenesDosificacion", x => x.IdOrdenDos);
                    table.ForeignKey(
                        name: "FK_OrdenesDosificacion_OrdenesProduccion_IdOrdenProd",
                        column: x => x.IdOrdenProd,
                        principalTable: "OrdenesProduccion",
                        principalColumn: "IdOrdenProd",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenesDosificacion_PanelesControl_IdOrdenPanel",
                        column: x => x.IdOrdenPanel,
                        principalTable: "PanelesControl",
                        principalColumn: "IdOrdenPanel",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDosificacion_IdOrdenDos",
                table: "OrdenesDosificacion",
                column: "IdOrdenDos",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDosificacion_IdOrdenPanel",
                table: "OrdenesDosificacion",
                column: "IdOrdenPanel");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesDosificacion_IdOrdenProd",
                table: "OrdenesDosificacion",
                column: "IdOrdenProd");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesProduccion_IdLogin",
                table: "OrdenesProduccion",
                column: "IdLogin");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesProduccion_IdOrdenPanel",
                table: "OrdenesProduccion",
                column: "IdOrdenPanel");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenesProduccion_IdOrdenProd",
                table: "OrdenesProduccion",
                column: "IdOrdenProd",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PanelesControl_IdLogin",
                table: "PanelesControl",
                column: "IdLogin");

            migrationBuilder.CreateIndex(
                name: "IX_PanelesControl_IdOrdenPanel",
                table: "PanelesControl",
                column: "IdOrdenPanel",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdenesDosificacion");

            migrationBuilder.DropTable(
                name: "OrdenesProduccion");

            migrationBuilder.DropTable(
                name: "PanelesControl");

            migrationBuilder.RenameColumn(
                name: "IdLogin",
                table: "Usuarios",
                newName: "idLogin");

            migrationBuilder.AlterColumn<string>(
                name: "usuario",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.CreateTable(
                name: "Producciones",
                columns: table => new
                {
                    idOrdenProd = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioidLogin = table.Column<int>(type: "int", nullable: false),
                    cantidadLitros = table.Column<double>(type: "float", nullable: false),
                    codProd = table.Column<int>(type: "int", nullable: false),
                    fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    idLogin = table.Column<int>(type: "int", nullable: false),
                    maquinaria = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    matPrima = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    prioridad = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}

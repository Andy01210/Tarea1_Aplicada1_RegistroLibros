using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro.Migrations
{
    /// <inheritdoc />
    public partial class SolucionSimpleDevolucion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Devoluciones_Estudiantes_EstudianteId",
                table: "Devoluciones");

            migrationBuilder.DropForeignKey(
                name: "FK_Devoluciones_Libro_LibroId",
                table: "Devoluciones");

            migrationBuilder.DropIndex(
                name: "IX_Devoluciones_EstudianteId",
                table: "Devoluciones");

            migrationBuilder.DropIndex(
                name: "IX_Devoluciones_LibroId",
                table: "Devoluciones");

            migrationBuilder.DropColumn(
                name: "EstudianteId",
                table: "Devoluciones");

            migrationBuilder.DropColumn(
                name: "LibroId",
                table: "Devoluciones");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EstudianteId",
                table: "Devoluciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LibroId",
                table: "Devoluciones",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_EstudianteId",
                table: "Devoluciones",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Devoluciones_LibroId",
                table: "Devoluciones",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Devoluciones_Estudiantes_EstudianteId",
                table: "Devoluciones",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "EstudianteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Devoluciones_Libro_LibroId",
                table: "Devoluciones",
                column: "LibroId",
                principalTable: "Libro",
                principalColumn: "LibroId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

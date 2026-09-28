using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Registro.Migrations
{
    /// <inheritdoc />
    public partial class Update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EstuianteId",
                table: "Prestamos",
                newName: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_EstudianteId",
                table: "Prestamos",
                column: "EstudianteId");

            migrationBuilder.CreateIndex(
                name: "IX_Prestamos_LibroId",
                table: "Prestamos",
                column: "LibroId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Estudiantes_EstudianteId",
                table: "Prestamos",
                column: "EstudianteId",
                principalTable: "Estudiantes",
                principalColumn: "EstudianteId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamos_Libro_LibroId",
                table: "Prestamos",
                column: "LibroId",
                principalTable: "Libro",
                principalColumn: "LibroId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Estudiantes_EstudianteId",
                table: "Prestamos");

            migrationBuilder.DropForeignKey(
                name: "FK_Prestamos_Libro_LibroId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_EstudianteId",
                table: "Prestamos");

            migrationBuilder.DropIndex(
                name: "IX_Prestamos_LibroId",
                table: "Prestamos");

            migrationBuilder.RenameColumn(
                name: "EstudianteId",
                table: "Prestamos",
                newName: "EstuianteId");
        }
    }
}

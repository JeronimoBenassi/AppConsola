using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AgregaHerenciaEstudianteProfesor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Usuario",
                type: "TEXT",
                maxLength: 13,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Especialidad",
                table: "Usuario",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Legajo",
                table: "Usuario",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Promedio",
                table: "Usuario",
                type: "REAL",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "Sueldo",
                table: "Usuario",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Especialidad",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Legajo",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Promedio",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "Sueldo",
                table: "Usuario");
        }
    }
}

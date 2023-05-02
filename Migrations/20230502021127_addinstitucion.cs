using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tp2.Migrations
{
    /// <inheritdoc />
    public partial class addinstitucion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstitucionId",
                table: "Estudiante",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Institucion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nombre = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Institucion", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Estudiante_InstitucionId",
                table: "Estudiante",
                column: "InstitucionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estudiante_Institucion_InstitucionId",
                table: "Estudiante",
                column: "InstitucionId",
                principalTable: "Institucion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estudiante_Institucion_InstitucionId",
                table: "Estudiante");

            migrationBuilder.DropTable(
                name: "Institucion");

            migrationBuilder.DropIndex(
                name: "IX_Estudiante_InstitucionId",
                table: "Estudiante");

            migrationBuilder.DropColumn(
                name: "InstitucionId",
                table: "Estudiante");
        }
    }
}

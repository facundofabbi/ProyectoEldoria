using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoEldoria.Migrations
{
    /// <inheritdoc />
    public partial class MigracionMentor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aventurero_Persona_MentorCodigo",
                table: "Aventurero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persona",
                table: "Persona");

            migrationBuilder.RenameTable(
                name: "Persona",
                newName: "Mentor");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Aventurero_Mentor_MentorCodigo",
                table: "Aventurero",
                column: "MentorCodigo",
                principalTable: "Mentor",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Aventurero_Mentor_MentorCodigo",
                table: "Aventurero");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Mentor",
                table: "Mentor");

            migrationBuilder.RenameTable(
                name: "Mentor",
                newName: "Persona");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persona",
                table: "Persona",
                column: "Codigo");

            migrationBuilder.AddForeignKey(
                name: "FK_Aventurero_Persona_MentorCodigo",
                table: "Aventurero",
                column: "MentorCodigo",
                principalTable: "Persona",
                principalColumn: "Codigo",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

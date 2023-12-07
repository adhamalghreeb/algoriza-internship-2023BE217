using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ve2.Migrations
{
    /// <inheritdoc />
    public partial class mg_spec : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Specialty",
                table: "Users");

            migrationBuilder.AddColumn<int>(
                name: "SpecialtyId",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Specialty",
                columns: table => new
                {
                    SpecialtyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Specialty", x => x.SpecialtyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SpecialtyId",
                table: "Users",
                column: "SpecialtyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Specialty_SpecialtyId",
                table: "Users",
                column: "SpecialtyId",
                principalTable: "Specialty",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Specialty_SpecialtyId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "Specialty");

            migrationBuilder.DropIndex(
                name: "IX_Users_SpecialtyId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "SpecialtyId",
                table: "Users");

            migrationBuilder.AddColumn<string>(
                name: "Specialty",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

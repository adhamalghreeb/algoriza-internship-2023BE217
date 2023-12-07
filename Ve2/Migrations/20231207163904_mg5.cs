using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Ve2.Migrations
{
    /// <inheritdoc />
    public partial class mg5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Specialties_SpecialtyId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Specialties_SpecialtyId",
                table: "Users",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "SpecialtyId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Specialties_SpecialtyId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Specialties_SpecialtyId",
                table: "Users",
                column: "SpecialtyId",
                principalTable: "Specialties",
                principalColumn: "SpecialtyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

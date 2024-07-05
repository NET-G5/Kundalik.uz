using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kundalik.Uz.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Class_Class_id",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_Class_id",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "Class_id",
                table: "Teacher");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Class_id",
                table: "Teacher",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_Class_id",
                table: "Teacher",
                column: "Class_id",
                unique: true,
                filter: "[Class_id] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Class_Class_id",
                table: "Teacher",
                column: "Class_id",
                principalTable: "Class",
                principalColumn: "Id");
        }
    }
}

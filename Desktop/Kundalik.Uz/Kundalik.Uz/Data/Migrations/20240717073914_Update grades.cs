using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kundalik.Uz.Data.Migrations
{
    /// <inheritdoc />
    public partial class Updategrades : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Term",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Term",
                table: "Grades");
        }
    }
}

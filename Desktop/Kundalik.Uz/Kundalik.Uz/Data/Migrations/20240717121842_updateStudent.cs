using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kundalik.Uz.Data.Migrations
{
    /// <inheritdoc />
    public partial class updateStudent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "CanLoadMore",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Footer",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Header",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Icon",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsBusy",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsNotBusy",
                table: "Student",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Subtitle",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Student",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StudentId1",
                table: "Grades",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Grades_StudentId1",
                table: "Grades",
                column: "StudentId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_Student_StudentId1",
                table: "Grades",
                column: "StudentId1",
                principalTable: "Student",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_Student_StudentId1",
                table: "Grades");

            migrationBuilder.DropIndex(
                name: "IX_Grades_StudentId1",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "CanLoadMore",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Footer",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Header",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Icon",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "IsBusy",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "IsNotBusy",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Subtitle",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Student");

            migrationBuilder.DropColumn(
                name: "StudentId1",
                table: "Grades");
        }
    }
}

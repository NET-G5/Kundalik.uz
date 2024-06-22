using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kundalik.Uz.Data.Migrations
{
    /// <inheritdoc />
    public partial class UpdateDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_TeacherSubject_TeacherSubjectTeacherId_TeacherSubjectSubjectId",
                table: "Grades");

            migrationBuilder.DropColumn(
                name: "TeacherSubjectId",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "TeacherSubjectTeacherId",
                table: "Grades",
                newName: "TeacherId");

            migrationBuilder.RenameColumn(
                name: "TeacherSubjectSubjectId",
                table: "Grades",
                newName: "SubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_TeacherSubjectTeacherId_TeacherSubjectSubjectId",
                table: "Grades",
                newName: "IX_Grades_TeacherId_SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_TeacherSubject_TeacherId_SubjectId",
                table: "Grades",
                columns: new[] { "TeacherId", "SubjectId" },
                principalTable: "TeacherSubject",
                principalColumns: new[] { "TeacherId", "SubjectId" },
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grades_TeacherSubject_TeacherId_SubjectId",
                table: "Grades");

            migrationBuilder.RenameColumn(
                name: "TeacherId",
                table: "Grades",
                newName: "TeacherSubjectTeacherId");

            migrationBuilder.RenameColumn(
                name: "SubjectId",
                table: "Grades",
                newName: "TeacherSubjectSubjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Grades_TeacherId_SubjectId",
                table: "Grades",
                newName: "IX_Grades_TeacherSubjectTeacherId_TeacherSubjectSubjectId");

            migrationBuilder.AddColumn<int>(
                name: "TeacherSubjectId",
                table: "Grades",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Grades_TeacherSubject_TeacherSubjectTeacherId_TeacherSubjectSubjectId",
                table: "Grades",
                columns: new[] { "TeacherSubjectTeacherId", "TeacherSubjectSubjectId" },
                principalTable: "TeacherSubject",
                principalColumns: new[] { "TeacherId", "SubjectId" },
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CortosoUniversity.Migrations
{
    public partial class ProperIDs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Course_CoursesCourseID",
                table: "CourseInstructor");

            migrationBuilder.RenameColumn(
                name: "EnrollmentID",
                table: "Enrollments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "DepartmentID",
                table: "Departments",
                newName: "ID");

            migrationBuilder.RenameColumn(
                name: "CoursesCourseID",
                table: "CourseInstructor",
                newName: "CoursesID");

            migrationBuilder.RenameColumn(
                name: "CourseID",
                table: "Course",
                newName: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Course_CoursesID",
                table: "CourseInstructor",
                column: "CoursesID",
                principalTable: "Course",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Course_CoursesID",
                table: "CourseInstructor");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Enrollments",
                newName: "EnrollmentID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Departments",
                newName: "DepartmentID");

            migrationBuilder.RenameColumn(
                name: "CoursesID",
                table: "CourseInstructor",
                newName: "CoursesCourseID");

            migrationBuilder.RenameColumn(
                name: "ID",
                table: "Course",
                newName: "CourseID");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Course_CoursesCourseID",
                table: "CourseInstructor",
                column: "CoursesCourseID",
                principalTable: "Course",
                principalColumn: "CourseID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

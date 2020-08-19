using Microsoft.EntityFrameworkCore.Migrations;

namespace Student_Management_System_Jassi.Data.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Student_Courses",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Course_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Courses", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student_Teachers",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Teachers", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Student_Admissions",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Student_CourseID = table.Column<int>(nullable: true),
                    Student_TeacherID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student_Admissions", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Student_Admissions_Student_Courses_Student_CourseID",
                        column: x => x.Student_CourseID,
                        principalTable: "Student_Courses",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Student_Admissions_Student_Teachers_Student_TeacherID",
                        column: x => x.Student_TeacherID,
                        principalTable: "Student_Teachers",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Student_Admissions_Student_CourseID",
                table: "Student_Admissions",
                column: "Student_CourseID");

            migrationBuilder.CreateIndex(
                name: "IX_Student_Admissions_Student_TeacherID",
                table: "Student_Admissions",
                column: "Student_TeacherID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Student_Admissions");

            migrationBuilder.DropTable(
                name: "Student_Courses");

            migrationBuilder.DropTable(
                name: "Student_Teachers");
        }
    }
}

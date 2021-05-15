using Microsoft.EntityFrameworkCore.Migrations;

namespace CollegeSystem.DataModels.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentNumberID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MobilePhone = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentNumberID);
                });

            migrationBuilder.CreateTable(
                name: "Subjects",
                columns: table => new
                {
                    SubjectID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Credits = table.Column<int>(type: "int", nullable: false),
                    Semester = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subjects", x => x.SubjectID);
                });

            migrationBuilder.CreateTable(
                name: "StudentSubject",
                columns: table => new
                {
                    StudentsStudentNumberID = table.Column<int>(type: "int", nullable: false),
                    SubjectsSubjectID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentSubject", x => new { x.StudentsStudentNumberID, x.SubjectsSubjectID });
                    table.ForeignKey(
                        name: "FK_StudentSubject_Students_StudentsStudentNumberID",
                        column: x => x.StudentsStudentNumberID,
                        principalTable: "Students",
                        principalColumn: "StudentNumberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentSubject_Subjects_SubjectsSubjectID",
                        column: x => x.SubjectsSubjectID,
                        principalTable: "Subjects",
                        principalColumn: "SubjectID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentNumberID", "Email", "FullName", "MobilePhone" },
                values: new object[,]
                {
                    { 1, "bob.bobsky@gmail.com", "Bob Bobsky", "38971634256" },
                    { 2, "jill.wayne@gmail.com", "Jill Wayne", "38971567489" }
                });

            migrationBuilder.InsertData(
                table: "Subjects",
                columns: new[] { "SubjectID", "Credits", "Name", "Semester" },
                values: new object[,]
                {
                    { 1, 3, "Mathematics", 1 },
                    { 2, 5, "English", 2 },
                    { 3, 10, "Programming and Advanced Programming", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentSubject_SubjectsSubjectID",
                table: "StudentSubject",
                column: "SubjectsSubjectID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentSubject");

            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Subjects");
        }
    }
}

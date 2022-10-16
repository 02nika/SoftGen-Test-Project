using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestExerciseSoftGen.Migrations
{
    public partial class mappingtableschanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group_Teacher_Student_Mappings");

            migrationBuilder.CreateTable(
                name: "Group_Student_Mappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Student_Mappings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group_Teacher_Mappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Teacher_Mappings", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Group_Student_Mappings");

            migrationBuilder.DropTable(
                name: "Group_Teacher_Mappings");

            migrationBuilder.CreateTable(
                name: "Group_Teacher_Student_Mappings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: true),
                    TeacherId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Teacher_Student_Mappings", x => x.Id);
                });
        }
    }
}

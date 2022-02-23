using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EF_Assignment1.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    StudentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(name: "First Name", type: "ntext", nullable: false),
                    LastName = table.Column<string>(name: "Last Name", type: "ntext", nullable: false),
                    City = table.Column<string>(type: "ntext", nullable: false),
                    State = table.Column<string>(type: "ntext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.StudentId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");
        }
    }
}

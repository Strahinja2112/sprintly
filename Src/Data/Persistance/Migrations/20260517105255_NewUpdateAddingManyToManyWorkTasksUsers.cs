using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprintra.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateAddingManyToManyWorkTasksUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeWorkTask",
                columns: table => new
                {
                    AssignedEmployeesId = table.Column<int>(type: "int", nullable: false),
                    AssignedTasksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeWorkTask", x => new { x.AssignedEmployeesId, x.AssignedTasksId });
                    table.ForeignKey(
                        name: "FK_EmployeeWorkTask_Employees_AssignedEmployeesId",
                        column: x => x.AssignedEmployeesId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeWorkTask_WorkTasks_AssignedTasksId",
                        column: x => x.AssignedTasksId,
                        principalTable: "WorkTasks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeWorkTask_AssignedTasksId",
                table: "EmployeeWorkTask",
                column: "AssignedTasksId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeWorkTask");
        }
    }
}

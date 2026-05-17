using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprintra.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AnotherRefactor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkTask_Employees_AssignedEmployeesId",
                table: "EmployeeWorkTask");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeWorkTask_WorkTasks_AssignedTasksId",
                table: "EmployeeWorkTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeWorkTask",
                table: "EmployeeWorkTask");

            migrationBuilder.RenameTable(
                name: "EmployeeWorkTask",
                newName: "Employee_AssignedTo_WorkTask");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeWorkTask_AssignedTasksId",
                table: "Employee_AssignedTo_WorkTask",
                newName: "IX_Employee_AssignedTo_WorkTask_AssignedTasksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_AssignedTo_WorkTask",
                table: "Employee_AssignedTo_WorkTask",
                columns: new[] { "AssignedEmployeesId", "AssignedTasksId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AssignedTo_WorkTask_Employees_AssignedEmployeesId",
                table: "Employee_AssignedTo_WorkTask",
                column: "AssignedEmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_AssignedTo_WorkTask_WorkTasks_AssignedTasksId",
                table: "Employee_AssignedTo_WorkTask",
                column: "AssignedTasksId",
                principalTable: "WorkTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AssignedTo_WorkTask_Employees_AssignedEmployeesId",
                table: "Employee_AssignedTo_WorkTask");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_AssignedTo_WorkTask_WorkTasks_AssignedTasksId",
                table: "Employee_AssignedTo_WorkTask");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_AssignedTo_WorkTask",
                table: "Employee_AssignedTo_WorkTask");

            migrationBuilder.RenameTable(
                name: "Employee_AssignedTo_WorkTask",
                newName: "EmployeeWorkTask");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_AssignedTo_WorkTask_AssignedTasksId",
                table: "EmployeeWorkTask",
                newName: "IX_EmployeeWorkTask_AssignedTasksId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeWorkTask",
                table: "EmployeeWorkTask",
                columns: new[] { "AssignedEmployeesId", "AssignedTasksId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkTask_Employees_AssignedEmployeesId",
                table: "EmployeeWorkTask",
                column: "AssignedEmployeesId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeWorkTask_WorkTasks_AssignedTasksId",
                table: "EmployeeWorkTask",
                column: "AssignedTasksId",
                principalTable: "WorkTasks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

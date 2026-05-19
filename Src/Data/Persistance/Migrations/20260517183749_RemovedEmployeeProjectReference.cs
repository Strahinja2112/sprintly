using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprintly.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RemovedEmployeeProjectReference : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_WorksOn_Project_Employees_MembersId",
                table: "Employee_WorksOn_Project");

            migrationBuilder.DropForeignKey(
                name: "FK_Employee_WorksOn_Project_Projects_ProjectsId",
                table: "Employee_WorksOn_Project");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee_WorksOn_Project",
                table: "Employee_WorksOn_Project");

            migrationBuilder.RenameTable(
                name: "Employee_WorksOn_Project",
                newName: "EmployeeProject");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_WorksOn_Project_ProjectsId",
                table: "EmployeeProject",
                newName: "IX_EmployeeProject_ProjectsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeProject",
                table: "EmployeeProject",
                columns: new[] { "MembersId", "ProjectsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProject_Employees_MembersId",
                table: "EmployeeProject",
                column: "MembersId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeProject_Projects_ProjectsId",
                table: "EmployeeProject",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProject_Employees_MembersId",
                table: "EmployeeProject");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeProject_Projects_ProjectsId",
                table: "EmployeeProject");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeProject",
                table: "EmployeeProject");

            migrationBuilder.RenameTable(
                name: "EmployeeProject",
                newName: "Employee_WorksOn_Project");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeProject_ProjectsId",
                table: "Employee_WorksOn_Project",
                newName: "IX_Employee_WorksOn_Project_ProjectsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee_WorksOn_Project",
                table: "Employee_WorksOn_Project",
                columns: new[] { "MembersId", "ProjectsId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_WorksOn_Project_Employees_MembersId",
                table: "Employee_WorksOn_Project",
                column: "MembersId",
                principalTable: "Employees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_WorksOn_Project_Projects_ProjectsId",
                table: "Employee_WorksOn_Project",
                column: "ProjectsId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

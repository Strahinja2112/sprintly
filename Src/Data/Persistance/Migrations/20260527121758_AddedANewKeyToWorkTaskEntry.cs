using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprintly.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedANewKeyToWorkTaskEntry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTaskEntries",
                table: "WorkTaskEntries");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "WorkTaskEntries",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTaskEntries",
                table: "WorkTaskEntries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WorkTaskEntries_EmployeeId",
                table: "WorkTaskEntries",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WorkTaskEntries",
                table: "WorkTaskEntries");

            migrationBuilder.DropIndex(
                name: "IX_WorkTaskEntries_EmployeeId",
                table: "WorkTaskEntries");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "WorkTaskEntries");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WorkTaskEntries",
                table: "WorkTaskEntries",
                columns: new[] { "EmployeeId", "WorkTaskId", "WorkDate" });
        }
    }
}

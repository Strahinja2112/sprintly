using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprintly.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class FixWorkTaskCascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserStories_Sprints_SprintId",
                table: "UserStories");

            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_Sprints_SprintId",
                table: "WorkTasks");

            migrationBuilder.DropIndex(
                name: "IX_UserStories_SprintId",
                table: "UserStories");

            migrationBuilder.DropColumn(
                name: "SprintId",
                table: "UserStories");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTasks_Sprints_SprintId",
                table: "WorkTasks",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_Sprints_SprintId",
                table: "WorkTasks");

            migrationBuilder.AddColumn<int>(
                name: "SprintId",
                table: "UserStories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserStories_SprintId",
                table: "UserStories",
                column: "SprintId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserStories_Sprints_SprintId",
                table: "UserStories",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTasks_Sprints_SprintId",
                table: "WorkTasks",
                column: "SprintId",
                principalTable: "Sprints",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

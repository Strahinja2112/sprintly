using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprintra.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class NewUpdateOdkudZnamVise : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_WorkTasks_UserStories_UserStoryId1",
                table: "WorkTasks");

            migrationBuilder.DropIndex(
                name: "IX_WorkTasks_UserStoryId1",
                table: "WorkTasks");

            migrationBuilder.DropColumn(
                name: "UserStoryId1",
                table: "WorkTasks");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserStoryId1",
                table: "WorkTasks",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_WorkTasks_UserStoryId1",
                table: "WorkTasks",
                column: "UserStoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_WorkTasks_UserStories_UserStoryId1",
                table: "WorkTasks",
                column: "UserStoryId1",
                principalTable: "UserStories",
                principalColumn: "Id");
        }
    }
}

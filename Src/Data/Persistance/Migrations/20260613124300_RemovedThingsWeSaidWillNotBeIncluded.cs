using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprintly.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RemovedThingsWeSaidWillNotBeIncluded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sprints_Distributions_DistributionId",
                table: "Sprints");

            migrationBuilder.DropTable(
                name: "Features");

            migrationBuilder.DropTable(
                name: "Increments");

            migrationBuilder.DropTable(
                name: "Distributions");

            migrationBuilder.DropIndex(
                name: "IX_Sprints_DistributionId",
                table: "Sprints");

            migrationBuilder.DropColumn(
                name: "DistributionId",
                table: "Sprints");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DistributionId",
                table: "Sprints",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Distributions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Environment = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Version = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Distributions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Increments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DistributionId = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Increments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Increments_Distributions_DistributionId",
                        column: x => x.DistributionId,
                        principalTable: "Distributions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Features",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IncrementId = table.Column<int>(type: "int", nullable: false),
                    SprintId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(600)", maxLength: 600, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Features", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Features_Increments_IncrementId",
                        column: x => x.IncrementId,
                        principalTable: "Increments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Features_Sprints_SprintId",
                        column: x => x.SprintId,
                        principalTable: "Sprints",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sprints_DistributionId",
                table: "Sprints",
                column: "DistributionId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_IncrementId",
                table: "Features",
                column: "IncrementId");

            migrationBuilder.CreateIndex(
                name: "IX_Features_SprintId",
                table: "Features",
                column: "SprintId");

            migrationBuilder.CreateIndex(
                name: "IX_Increments_DistributionId",
                table: "Increments",
                column: "DistributionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sprints_Distributions_DistributionId",
                table: "Sprints",
                column: "DistributionId",
                principalTable: "Distributions",
                principalColumn: "Id");
        }
    }
}

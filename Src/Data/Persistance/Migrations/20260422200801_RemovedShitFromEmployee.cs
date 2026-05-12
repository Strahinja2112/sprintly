using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sprintra.Data.Persistance.Migrations
{
    /// <inheritdoc />
    public partial class RemovedShitFromEmployee : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CertificationLevel",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "ProductDomain",
                table: "Employees");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CertificationLevel",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProductDomain",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

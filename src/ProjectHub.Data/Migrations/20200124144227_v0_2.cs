using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHub.Data.Migrations
{
    public partial class v0_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 1, "For development purposes.", "Develop" });

            migrationBuilder.InsertData(
                table: "Environments",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "For testing and quality assurance.", "Test" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Environments",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

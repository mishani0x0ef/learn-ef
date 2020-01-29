using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHub.Data.Migrations
{
    public partial class v0_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "SiteLinks",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "SiteLinks",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "Environments",
                nullable: false,
                defaultValueSql: "getdate()");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModified",
                table: "Environments",
                nullable: false,
                defaultValueSql: "getdate()");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "SiteLinks");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "SiteLinks");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Environments");

            migrationBuilder.DropColumn(
                name: "LastModified",
                table: "Environments");
        }
    }
}

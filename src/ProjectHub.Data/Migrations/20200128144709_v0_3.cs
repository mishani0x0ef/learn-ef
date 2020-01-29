using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHub.Data.Migrations
{
    public partial class v0_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteLinkHashTag_HashTag_HashTagId",
                table: "SiteLinkHashTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HashTag",
                table: "HashTag");

            migrationBuilder.RenameTable(
                name: "HashTag",
                newName: "HashTags");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HashTags",
                table: "HashTags",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteLinkHashTag_HashTags_HashTagId",
                table: "SiteLinkHashTag",
                column: "HashTagId",
                principalTable: "HashTags",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SiteLinkHashTag_HashTags_HashTagId",
                table: "SiteLinkHashTag");

            migrationBuilder.DropPrimaryKey(
                name: "PK_HashTags",
                table: "HashTags");

            migrationBuilder.RenameTable(
                name: "HashTags",
                newName: "HashTag");

            migrationBuilder.AddPrimaryKey(
                name: "PK_HashTag",
                table: "HashTag",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SiteLinkHashTag_HashTag_HashTagId",
                table: "SiteLinkHashTag",
                column: "HashTagId",
                principalTable: "HashTag",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

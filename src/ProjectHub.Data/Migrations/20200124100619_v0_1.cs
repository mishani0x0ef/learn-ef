using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHub.Data.Migrations
{
    public partial class v0_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HashTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HashTag", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteLinkHashTag",
                columns: table => new
                {
                    SiteLinkId = table.Column<int>(nullable: false),
                    HashTagId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteLinkHashTag", x => new { x.SiteLinkId, x.HashTagId });
                    table.ForeignKey(
                        name: "FK_SiteLinkHashTag_HashTag_HashTagId",
                        column: x => x.HashTagId,
                        principalTable: "HashTag",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteLinkHashTag_SiteLinks_SiteLinkId",
                        column: x => x.SiteLinkId,
                        principalTable: "SiteLinks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SiteLinkHashTag_HashTagId",
                table: "SiteLinkHashTag",
                column: "HashTagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteLinkHashTag");

            migrationBuilder.DropTable(
                name: "HashTag");
        }
    }
}

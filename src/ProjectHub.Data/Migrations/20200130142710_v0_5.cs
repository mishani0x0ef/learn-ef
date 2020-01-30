using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHub.Data.Migrations
{
    public partial class v0_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                create function GetLatestEnvironment ()
                returns int as
                begin
                	declare @environmentId int
                	select top 1 
                		@environmentId = e.Id
                	from Environments e
                	order by e.CreatedAt desc
                
                	return @environmentId
                end
                go
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                drop function GetLatestEnvironment
                go
            ");
        }
    }
}

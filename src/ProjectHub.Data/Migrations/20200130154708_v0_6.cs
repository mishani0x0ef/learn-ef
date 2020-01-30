using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectHub.Data.Migrations
{
    public partial class v0_6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
create view EnvironmentDetails
as
select
    e.Id,
    e.Name,
    e.Description,
    count(s.Id) as SitesCount,
    e.LastModified
from
    dbo.Environments e
join 
    dbo.SiteLinks s on s.EnvironmentId = e.Id
group by
	e.Id,
	e.Name,
    e.Description,
	e.LastModified
go
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
drop view EnvironmentDetails
");
        }
    }
}

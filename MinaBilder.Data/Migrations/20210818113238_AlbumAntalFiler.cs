using Microsoft.EntityFrameworkCore.Migrations;

namespace MinaBilder.Data.Migrations
{
    public partial class AlbumAntalFiler : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                create view dbo.AlbumAntalFiler
                as
	                select a.id AlbumId, a.Namn AlbumNamn, count(af.FilerId) AntalFiler
	                from Album a
	                join AlbumFil af on af.AlbumId = a.Id
	                group by a.id, a.Namn	            
                ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                @"
                    drop view dbo.AlbumAntalFiler
            ");
        }
    }
}

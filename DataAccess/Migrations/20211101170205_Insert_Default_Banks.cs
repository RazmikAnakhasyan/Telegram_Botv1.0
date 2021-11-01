using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class Insert_Default_Banks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"INSERT INTO  [dbo].[Banks]
VALUES('Ameria Bank','https://ameriabank.am/'),
	  ('Evoca Bank', 'https://www.evoca.am'),
	  ('ACBA Bank', 'https://www.acba.am/'),
	  ('Ineco Bank', 'https://www.inecobank.am/hy/Individual'),
	  ('Unibank', 'https://www.unibank.am/hy/')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM [dbo].[Banks]");
        }
    }
}

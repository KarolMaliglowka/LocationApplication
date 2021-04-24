using Microsoft.EntityFrameworkCore.Migrations;

namespace LA.Infrastructure.Migrations
{
    public partial class addedNewField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneId",
                table: "Devices",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PhoneId",
                table: "Devices");
        }
    }
}

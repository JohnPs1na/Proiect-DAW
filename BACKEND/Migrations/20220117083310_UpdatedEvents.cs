using Microsoft.EntityFrameworkCore.Migrations;

namespace MYZONE.Migrations
{
    public partial class UpdatedEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TicketNum",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TicketNum",
                table: "Events");
        }
    }
}

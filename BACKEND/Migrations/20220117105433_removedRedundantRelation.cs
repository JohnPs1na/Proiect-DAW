using Microsoft.EntityFrameworkCore.Migrations;

namespace MYZONE.Migrations
{
    public partial class removedRedundantRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_BasicUsers_BasicUserId",
                table: "Tickets");

            migrationBuilder.DropIndex(
                name: "IX_Tickets_BasicUserId",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "BasicUserId",
                table: "Tickets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BasicUserId",
                table: "Tickets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tickets_BasicUserId",
                table: "Tickets",
                column: "BasicUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tickets_BasicUsers_BasicUserId",
                table: "Tickets",
                column: "BasicUserId",
                principalTable: "BasicUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

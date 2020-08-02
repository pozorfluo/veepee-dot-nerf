using Microsoft.EntityFrameworkCore.Migrations;

namespace VeepeeDotNerf.Migrations
{
    public partial class RemoveClientEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_client_email",
                table: "client");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_client_email",
                table: "client",
                column: "email",
                unique: true);
        }
    }
}

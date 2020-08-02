using Microsoft.EntityFrameworkCore.Migrations;

namespace VeepeeDotNerf.Migrations
{
    public partial class UniqueKeyClientEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_client_email",
                table: "client",
                column: "email",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_client_email",
                table: "client");
        }
    }
}

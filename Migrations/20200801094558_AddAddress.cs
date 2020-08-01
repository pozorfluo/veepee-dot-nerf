using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VeepeeDotNerf.Migrations
{
    public partial class AddAddress : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Address",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<string>(nullable: true),
                    firstName = table.Column<string>(nullable: true),
                    lastName = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    addressComplement = table.Column<string>(nullable: true),
                    city = table.Column<string>(nullable: true),
                    zipCode = table.Column<string>(nullable: true),
                    country = table.Column<string>(nullable: true),
                    phone = table.Column<string>(nullable: true),
                    createdAt = table.Column<DateTime>(nullable: false),
                    updatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Address", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Address");
        }
    }
}

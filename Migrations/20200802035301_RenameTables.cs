using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VeepeeDotNerf.Migrations
{
    public partial class RenameTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "client",
                columns: table => new
                {
                    client_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_client", x => x.client_id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                columns: table => new
                {
                    country_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(type: "varchar(255)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.country_id);
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    sku = table.Column<string>(type: "varchar(255)", nullable: false),
                    name = table.Column<string>(type: "varchar(255)", nullable: false),
                    description = table.Column<string>(maxLength: 500, nullable: false),
                    price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    msrp = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    inventory = table.Column<int>(nullable: false),
                    image = table.Column<string>(type: "varchar(255)", nullable: false),
                    hot = table.Column<bool>(nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                });

            migrationBuilder.CreateTable(
                name: "address",
                columns: table => new
                {
                    address_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    type = table.Column<string>(type: "varchar(32)", nullable: false),
                    first_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    last_name = table.Column<string>(type: "varchar(255)", nullable: false),
                    email = table.Column<string>(type: "varchar(255)", nullable: false),
                    line1 = table.Column<string>(type: "varchar(255)", nullable: false),
                    line2 = table.Column<string>(type: "varchar(255)", nullable: false),
                    city = table.Column<string>(type: "varchar(255)", nullable: false),
                    zip_code = table.Column<string>(type: "varchar(255)", nullable: false),
                    phone = table.Column<string>(type: "varchar(32)", nullable: false),
                    created_at = table.Column<DateTime>(nullable: false),
                    updated_at = table.Column<DateTime>(nullable: false),
                    country_id = table.Column<int>(nullable: false),
                    client_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_address", x => x.address_id);
                    table.ForeignKey(
                        name: "FK_address_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_address_country_country_id",
                        column: x => x.country_id,
                        principalTable: "country",
                        principalColumn: "country_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "order_info",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    payment_method = table.Column<string>(type: "varchar(32)", nullable: false),
                    total = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    api_order_id = table.Column<int>(nullable: false),
                    status = table.Column<string>(type: "varchar(32)", nullable: false),
                    client_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_info", x => x.order_id);
                    table.ForeignKey(
                        name: "FK_order_info_client_client_id",
                        column: x => x.client_id,
                        principalTable: "client",
                        principalColumn: "client_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_info_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_address_client_id",
                table: "address",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_address_country_id",
                table: "address",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_info_client_id",
                table: "order_info",
                column: "client_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_info_product_id",
                table: "order_info",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "address");

            migrationBuilder.DropTable(
                name: "order_info");

            migrationBuilder.DropTable(
                name: "country");

            migrationBuilder.DropTable(
                name: "client");

            migrationBuilder.DropTable(
                name: "product");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class CreateOrderModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order_status",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    slug = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_status", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    cart_id = table.Column<long>(type: "bigint", nullable: true),
                    ref_id = table.Column<string>(type: "text", nullable: false),
                    order_status_id = table.Column<long>(type: "bigint", nullable: false),
                    first_name = table.Column<string>(type: "text", nullable: false),
                    last_name = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    payment_provider = table.Column<string>(type: "text", nullable: false),
                    billing_address_line1 = table.Column<string>(type: "text", nullable: false),
                    billing_address_line2 = table.Column<string>(type: "text", nullable: true),
                    billing_address_country = table.Column<string>(type: "text", nullable: false),
                    billing_address_city = table.Column<string>(type: "text", nullable: false),
                    billing_address_postal_code = table.Column<string>(type: "text", nullable: false),
                    shipping_address_line1 = table.Column<string>(type: "text", nullable: false),
                    shipping_address_line2 = table.Column<string>(type: "text", nullable: true),
                    shipping_address_country = table.Column<string>(type: "text", nullable: false),
                    shipping_address_city = table.Column<string>(type: "text", nullable: false),
                    shipping_address_postal_code = table.Column<string>(type: "text", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_order_status_order_status_id",
                        column: x => x.order_status_id,
                        principalTable: "order_status",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_order_users_user_id",
                        column: x => x.user_id,
                        principalTable: "AspNetUsers",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "order_line_item",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    order_id = table.Column<long>(type: "bigint", nullable: false),
                    product_uuid = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    discount_price = table.Column<decimal>(type: "numeric", nullable: true),
                    quantity = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_order_line_item", x => x.id);
                    table.ForeignKey(
                        name: "fk_order_line_item_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "order_status",
                columns: new[] { "id", "name", "slug" },
                values: new object[,]
                {
                    { 1L, "Pending", "pending" },
                    { 2L, "Paid", "paid" },
                    { 3L, "Processing", "processing" },
                    { 4L, "Shipped", "shipped" },
                    { 5L, "Completed", "completed" },
                    { 6L, "Cancelled", "cancelled" }
                });

            migrationBuilder.CreateIndex(
                name: "ix_order_order_status_id",
                table: "order",
                column: "order_status_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_user_id",
                table: "order",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "ix_order_line_item_order_id",
                table: "order_line_item",
                column: "order_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_line_item");

            migrationBuilder.DropTable(
                name: "order");

            migrationBuilder.DropTable(
                name: "order_status");
        }
    }
}

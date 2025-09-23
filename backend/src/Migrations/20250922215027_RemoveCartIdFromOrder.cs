using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class RemoveCartIdFromOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_order_order_status_order_status_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "fk_order_users_user_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "fk_order_line_item_order_order_id",
                table: "order_line_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_status",
                table: "order_status");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_line_item",
                table: "order_line_item");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order",
                table: "order");

            migrationBuilder.DropColumn(
                name: "cart_id",
                table: "order");

            migrationBuilder.RenameTable(
                name: "order_status",
                newName: "order_statuses");

            migrationBuilder.RenameTable(
                name: "order_line_item",
                newName: "order_line_items");

            migrationBuilder.RenameTable(
                name: "order",
                newName: "orders");

            migrationBuilder.RenameIndex(
                name: "ix_order_line_item_order_id",
                table: "order_line_items",
                newName: "ix_order_line_items_order_id");

            migrationBuilder.RenameIndex(
                name: "ix_order_user_id",
                table: "orders",
                newName: "ix_orders_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_order_order_status_id",
                table: "orders",
                newName: "ix_orders_order_status_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_statuses",
                table: "order_statuses",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_line_items",
                table: "order_line_items",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_orders",
                table: "orders",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_order_line_items_orders_order_id",
                table: "order_line_items",
                column: "order_id",
                principalTable: "orders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orders_order_statuses_order_status_id",
                table: "orders",
                column: "order_status_id",
                principalTable: "order_statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_orders_users_user_id",
                table: "orders",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_order_line_items_orders_order_id",
                table: "order_line_items");

            migrationBuilder.DropForeignKey(
                name: "fk_orders_order_statuses_order_status_id",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "fk_orders_users_user_id",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_statuses",
                table: "order_statuses");

            migrationBuilder.DropPrimaryKey(
                name: "pk_order_line_items",
                table: "order_line_items");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "order");

            migrationBuilder.RenameTable(
                name: "order_statuses",
                newName: "order_status");

            migrationBuilder.RenameTable(
                name: "order_line_items",
                newName: "order_line_item");

            migrationBuilder.RenameIndex(
                name: "ix_orders_user_id",
                table: "order",
                newName: "ix_order_user_id");

            migrationBuilder.RenameIndex(
                name: "ix_orders_order_status_id",
                table: "order",
                newName: "ix_order_order_status_id");

            migrationBuilder.RenameIndex(
                name: "ix_order_line_items_order_id",
                table: "order_line_item",
                newName: "ix_order_line_item_order_id");

            migrationBuilder.AddColumn<long>(
                name: "cart_id",
                table: "order",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_order",
                table: "order",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_status",
                table: "order_status",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_order_line_item",
                table: "order_line_item",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_order_order_status_order_status_id",
                table: "order",
                column: "order_status_id",
                principalTable: "order_status",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_order_users_user_id",
                table: "order",
                column: "user_id",
                principalTable: "AspNetUsers",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_order_line_item_order_order_id",
                table: "order_line_item",
                column: "order_id",
                principalTable: "order",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

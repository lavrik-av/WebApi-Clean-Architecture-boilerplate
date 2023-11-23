using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Boilerplate.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class OrderProduct_Renamefields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ProductsId",
                table: "OrdersProducts",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "OrdersId",
                table: "OrdersProducts",
                newName: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrdersProducts",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrdersProducts",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Orders_OrderId",
                table: "OrdersProducts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                table: "OrdersProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Orders_OrderId",
                table: "OrdersProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderProduct_Products_ProductId",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_OrderId",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrderProduct_ProductId",
                table: "OrdersProducts");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "OrdersProducts",
                newName: "ProductsId");

            migrationBuilder.RenameColumn(
                name: "OrderId",
                table: "OrdersProducts",
                newName: "OrdersId");
        }
    }
}

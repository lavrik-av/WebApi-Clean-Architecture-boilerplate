using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Eshop.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Add_OrdersProducts_table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropForeignKey(
            //    name: "FK_OrdersProducts_Orders_OrdersId",
            //    table: "OrdersProducts");

            //migrationBuilder.DropForeignKey(
            //    name: "FK_OrdersProducts_Products_ProductsId",
            //    table: "OrdersProducts");

            //migrationBuilder.DropPrimaryKey(
            //    name: "PK_OrdersProducts",
            //    table: "OrdersProducts");

            //migrationBuilder.DropIndex(
            //    name: "IX_OrdersProducts_ProductsId",
            //    table: "OrdersProducts");

            //migrationBuilder.AddColumn<Guid>(
            //    name: "Id",
            //    table: "OrdersProducts",
            //    type: "uniqueidentifier",
            //    nullable: false,
            //    defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            //migrationBuilder.AddPrimaryKey(
            //    name: "PK_OrdersProducts",
            //    table: "OrdersProducts",
            //    column: "Id");

            migrationBuilder.CreateTable(
                name: "OrdersProducts",
                columns: table => new
                {
                    OrdersId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProductsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdersProducts", x => new { x.OrdersId, x.ProductsId });
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Orders_OrdersId",
                        column: x => x.OrdersId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdersProducts_Products_ProductsId",
                        column: x => x.ProductsId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductsId",
                table: "OrdersProducts",
                column: "ProductsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrdersProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "OrdersProducts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts",
                columns: new[] { "OrdersId", "ProductsId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductsId",
                table: "OrdersProducts",
                column: "ProductsId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Orders_OrdersId",
                table: "OrdersProducts",
                column: "OrdersId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Products_ProductsId",
                table: "OrdersProducts",
                column: "ProductsId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

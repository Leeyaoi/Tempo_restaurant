using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Tempo_DAL.Migrations
{
    /// <inheritdoc />
    public partial class FixedTablesAndOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Table",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "OrderEntityId",
                table: "Drink",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drink_OrderEntityId",
                table: "Drink",
                column: "OrderEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drink_Order_OrderEntityId",
                table: "Drink",
                column: "OrderEntityId",
                principalTable: "Order",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drink_Order_OrderEntityId",
                table: "Drink");

            migrationBuilder.DropIndex(
                name: "IX_Drink_OrderEntityId",
                table: "Drink");

            migrationBuilder.DropColumn(
                name: "Number",
                table: "Table");

            migrationBuilder.DropColumn(
                name: "OrderEntityId",
                table: "Drink");
        }
    }
}

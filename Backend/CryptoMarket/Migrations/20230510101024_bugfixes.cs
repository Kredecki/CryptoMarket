using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoMarket.Migrations
{
    public partial class bugfixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SpotTradingOrders_AspNetUsers_UserId",
                table: "SpotTradingOrders");

            migrationBuilder.DropForeignKey(
                name: "FK_SpotTradingOrders_SpotTradingPairs_SpotTradingPairId",
                table: "SpotTradingOrders");

            migrationBuilder.DropIndex(
                name: "IX_SpotTradingOrders_SpotTradingPairId",
                table: "SpotTradingOrders");

            migrationBuilder.DropIndex(
                name: "IX_SpotTradingOrders_UserId",
                table: "SpotTradingOrders");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserAssets",
                newName: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserAssets",
                newName: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpotTradingOrders_SpotTradingPairId",
                table: "SpotTradingOrders",
                column: "SpotTradingPairId");

            migrationBuilder.CreateIndex(
                name: "IX_SpotTradingOrders_UserId",
                table: "SpotTradingOrders",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_SpotTradingOrders_AspNetUsers_UserId",
                table: "SpotTradingOrders",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SpotTradingOrders_SpotTradingPairs_SpotTradingPairId",
                table: "SpotTradingOrders",
                column: "SpotTradingPairId",
                principalTable: "SpotTradingPairs",
                principalColumn: "SpotTradingPairId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

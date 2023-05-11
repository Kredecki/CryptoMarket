using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoMarket.Migrations
{
    public partial class Bugfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAssets_Currencies_CurrencyId",
                table: "UserAssets");

            migrationBuilder.DropIndex(
                name: "IX_UserAssets_CurrencyId",
                table: "UserAssets");

            migrationBuilder.RenameColumn(
                name: "CurrencyId",
                table: "UserAssets",
                newName: "CoinId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CoinId",
                table: "UserAssets",
                newName: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssets_CurrencyId",
                table: "UserAssets",
                column: "CurrencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAssets_Currencies_CurrencyId",
                table: "UserAssets",
                column: "CurrencyId",
                principalTable: "Currencies",
                principalColumn: "CurrencyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

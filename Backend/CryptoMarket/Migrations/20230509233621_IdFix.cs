using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CryptoMarket.Migrations
{
    public partial class IdFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAssets_AspNetUsers_UserId",
                table: "UserAssets");

            migrationBuilder.DropIndex(
                name: "IX_UserAssets_UserId",
                table: "UserAssets");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserAssets",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "UserAssets",
                newName: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAssets_UserId",
                table: "UserAssets",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAssets_AspNetUsers_UserId",
                table: "UserAssets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

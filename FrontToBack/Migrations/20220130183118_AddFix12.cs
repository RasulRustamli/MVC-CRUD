using Microsoft.EntityFrameworkCore.Migrations;

namespace FrontToBack.Migrations
{
    public partial class AddFix12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductId",
                table: "comments",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_comments_ProductId",
                table: "comments",
                column: "ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_comments_Products_ProductId",
                table: "comments",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_comments_Products_ProductId",
                table: "comments");

            migrationBuilder.DropIndex(
                name: "IX_comments_ProductId",
                table: "comments");

            migrationBuilder.DropColumn(
                name: "ProductId",
                table: "comments");
        }
    }
}

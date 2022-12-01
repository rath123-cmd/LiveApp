using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveApp.Migrations
{
    public partial class UpdateBooksInBookGallery : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_BookGallery_BookId",
                table: "BookGallery",
                column: "BookId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookGallery_Books_BookId",
                table: "BookGallery",
                column: "BookId",
                principalTable: "Books",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookGallery_Books_BookId",
                table: "BookGallery");

            migrationBuilder.DropIndex(
                name: "IX_BookGallery_BookId",
                table: "BookGallery");
        }
    }
}

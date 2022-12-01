using Microsoft.EntityFrameworkCore.Migrations;

namespace LiveApp.Migrations
{
    public partial class coverPhotoPathColumnAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CoverPhotoUrl",
                table: "Books",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CoverPhotoUrl",
                table: "Books");
        }
    }
}

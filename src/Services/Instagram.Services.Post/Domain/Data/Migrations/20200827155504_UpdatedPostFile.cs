using Microsoft.EntityFrameworkCore.Migrations;

namespace Instagram.Services.Post.Domain.Data.Migrations
{
    public partial class UpdatedPostFile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Thumbail",
                table: "PostFiles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Thumbail",
                table: "PostFiles");
        }
    }
}

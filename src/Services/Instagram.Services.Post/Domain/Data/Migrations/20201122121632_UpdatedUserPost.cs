using Microsoft.EntityFrameworkCore.Migrations;

namespace Instagram.Services.Post.Domain.Data.Migrations
{
    public partial class UpdatedUserPost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumOfLikes",
                table: "UserPosts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NumOfLikes",
                table: "UserPosts");
        }
    }
}

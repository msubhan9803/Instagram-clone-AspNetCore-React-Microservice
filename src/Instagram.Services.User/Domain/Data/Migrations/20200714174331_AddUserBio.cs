using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Instagram.Services.User.Domain.Data.Migrations
{
    public partial class AddUserBio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserBios",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    Text = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    WebsiteUrl = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserBios", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserBios");
        }
    }
}

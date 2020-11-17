using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Instagram.Services.User.Domain.Data.Migrations
{
    public partial class AddUserRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserRelations",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    FollowerId = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRelations", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRelations",
                table: "UserRelations");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "UserRelations");
        }
    }
}

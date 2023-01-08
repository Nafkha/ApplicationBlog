using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationBlog.DAL.Migrations
{
    public partial class Addedimagetopost : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "postImage",
                table: "posts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "postImage",
                table: "posts");
        }
    }
}

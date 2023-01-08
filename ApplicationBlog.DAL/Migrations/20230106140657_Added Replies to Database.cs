using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationBlog.DAL.Migrations
{
    public partial class AddedRepliestoDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reply_posts_PostId",
                table: "Reply");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reply",
                table: "Reply");

            migrationBuilder.RenameTable(
                name: "Reply",
                newName: "replies");

            migrationBuilder.RenameIndex(
                name: "IX_Reply_PostId",
                table: "replies",
                newName: "IX_replies_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_replies",
                table: "replies",
                column: "ReplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_replies_posts_PostId",
                table: "replies",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "postId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_replies_posts_PostId",
                table: "replies");

            migrationBuilder.DropPrimaryKey(
                name: "PK_replies",
                table: "replies");

            migrationBuilder.RenameTable(
                name: "replies",
                newName: "Reply");

            migrationBuilder.RenameIndex(
                name: "IX_replies_PostId",
                table: "Reply",
                newName: "IX_Reply_PostId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reply",
                table: "Reply",
                column: "ReplyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reply_posts_PostId",
                table: "Reply",
                column: "PostId",
                principalTable: "posts",
                principalColumn: "postId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationBlog.DAL.Migrations
{
    public partial class AddedOnDeleteCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_categories_categorieID",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_categorieID",
                table: "posts");

            migrationBuilder.DropColumn(
                name: "categorieID",
                table: "posts");

            migrationBuilder.CreateIndex(
                name: "IX_posts_CatId",
                table: "posts",
                column: "CatId");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_categories_CatId",
                table: "posts",
                column: "CatId",
                principalTable: "categories",
                principalColumn: "categorieID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_posts_categories_CatId",
                table: "posts");

            migrationBuilder.DropIndex(
                name: "IX_posts_CatId",
                table: "posts");

            migrationBuilder.AddColumn<int>(
                name: "categorieID",
                table: "posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_posts_categorieID",
                table: "posts",
                column: "categorieID");

            migrationBuilder.AddForeignKey(
                name: "FK_posts_categories_categorieID",
                table: "posts",
                column: "categorieID",
                principalTable: "categories",
                principalColumn: "categorieID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

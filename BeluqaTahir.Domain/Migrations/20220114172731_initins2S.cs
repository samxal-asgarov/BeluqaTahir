using Microsoft.EntityFrameworkCore.Migrations;

namespace BeluqaTahir.Domain.Migrations
{
    public partial class initins2S : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComment_BlogPostComment_ParentId1",
                table: "BlogPostComment");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComment_blogPosts_BlogPostId1",
                table: "BlogPostComment");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostComment",
                table: "BlogPostComment");

            migrationBuilder.RenameTable(
                name: "BlogPostComment",
                newName: "BlogPostComments");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostComment_ParentId1",
                table: "BlogPostComments",
                newName: "IX_BlogPostComments_ParentId1");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostComment_BlogPostId1",
                table: "BlogPostComments",
                newName: "IX_BlogPostComments_BlogPostId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostComments",
                table: "BlogPostComments",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_BlogPostComments_ParentId1",
                table: "BlogPostComments",
                column: "ParentId1",
                principalTable: "BlogPostComments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_blogPosts_BlogPostId1",
                table: "BlogPostComments",
                column: "BlogPostId1",
                principalTable: "blogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_BlogPostComments_ParentId1",
                table: "BlogPostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_blogPosts_BlogPostId1",
                table: "BlogPostComments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BlogPostComments",
                table: "BlogPostComments");

            migrationBuilder.RenameTable(
                name: "BlogPostComments",
                newName: "BlogPostComment");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostComments_ParentId1",
                table: "BlogPostComment",
                newName: "IX_BlogPostComment_ParentId1");

            migrationBuilder.RenameIndex(
                name: "IX_BlogPostComments_BlogPostId1",
                table: "BlogPostComment",
                newName: "IX_BlogPostComment_BlogPostId1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BlogPostComment",
                table: "BlogPostComment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComment_BlogPostComment_ParentId1",
                table: "BlogPostComment",
                column: "ParentId1",
                principalTable: "BlogPostComment",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComment_blogPosts_BlogPostId1",
                table: "BlogPostComment",
                column: "BlogPostId1",
                principalTable: "blogPosts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

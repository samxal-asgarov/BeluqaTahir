using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BeluqaTahir.Domain.Migrations
{
    public partial class initins2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlogPostComment",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlogPostId = table.Column<long>(type: "bigint", nullable: false),
                    BlogPostId1 = table.Column<int>(type: "int", nullable: true),
                    ParentId = table.Column<long>(type: "bigint", nullable: true),
                    ParentId1 = table.Column<int>(type: "int", nullable: true),
                    CreateByUserId = table.Column<int>(type: "int", nullable: true),
                    CreateData = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeleteByUserId = table.Column<int>(type: "int", nullable: true),
                    DeleteData = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlogPostComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlogPostComment_BlogPostComment_ParentId1",
                        column: x => x.ParentId1,
                        principalTable: "BlogPostComment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_BlogPostComment_blogPosts_BlogPostId1",
                        column: x => x.BlogPostId1,
                        principalTable: "blogPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComment_BlogPostId1",
                table: "BlogPostComment",
                column: "BlogPostId1");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComment_ParentId1",
                table: "BlogPostComment",
                column: "ParentId1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlogPostComment");
        }
    }
}

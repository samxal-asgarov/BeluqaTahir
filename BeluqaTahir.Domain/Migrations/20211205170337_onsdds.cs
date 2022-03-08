using Microsoft.EntityFrameworkCore.Migrations;

namespace BeluqaTahir.Domain.Migrations
{
    public partial class onsdds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Product_productTypes_ProductTypesId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "products");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ProductTypesId",
                table: "products",
                newName: "IX_products_ProductTypesId");

            migrationBuilder.AddColumn<string>(
                name: "ImagePati",
                table: "products",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_products",
                table: "products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_products_productTypes_ProductTypesId",
                table: "products",
                column: "ProductTypesId",
                principalTable: "productTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_productTypes_ProductTypesId",
                table: "products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_products",
                table: "products");

            migrationBuilder.DropColumn(
                name: "ImagePati",
                table: "products");

            migrationBuilder.RenameTable(
                name: "products",
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_products_ProductTypesId",
                table: "Product",
                newName: "IX_Product_ProductTypesId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_productTypes_ProductTypesId",
                table: "Product",
                column: "ProductTypesId",
                principalTable: "productTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

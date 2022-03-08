using Microsoft.EntityFrameworkCore.Migrations;

namespace BeluqaTahir.Domain.Migrations
{
    public partial class BlogPostComments1dsdfs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_subscrices_CreateByUserId",
                table: "subscrices",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_subscrices_DeleteByUserId",
                table: "subscrices",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_productTypes_CreateByUserId",
                table: "productTypes",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_productTypes_DeleteByUserId",
                table: "productTypes",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_products_CreateByUserId",
                table: "products",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_products_DeleteByUserId",
                table: "products",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_happyClients_CreateByUserId",
                table: "happyClients",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_happyClients_DeleteByUserId",
                table: "happyClients",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_CreateByUserId",
                table: "contacts",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_contacts_DeleteByUserId",
                table: "contacts",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_blogPosts_CreateByUserId",
                table: "blogPosts",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_blogPosts_DeleteByUserId",
                table: "blogPosts",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_CreateByUserId",
                table: "BlogPostComments",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_BlogPostComments_DeleteByUserId",
                table: "BlogPostComments",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_auditLogs_CreateByUserId",
                table: "auditLogs",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_auditLogs_DeleteByUserId",
                table: "auditLogs",
                column: "DeleteByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_accountdetails_CreateByUserId",
                table: "accountdetails",
                column: "CreateByUserId");

            migrationBuilder.CreateIndex(
                name: "IX_accountdetails_DeleteByUserId",
                table: "accountdetails",
                column: "DeleteByUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_accountdetails_Users_CreateByUserId",
                table: "accountdetails",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_accountdetails_Users_DeleteByUserId",
                table: "accountdetails",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_auditLogs_Users_CreateByUserId",
                table: "auditLogs",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_auditLogs_Users_DeleteByUserId",
                table: "auditLogs",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_Users_CreateByUserId",
                table: "BlogPostComments",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BlogPostComments_Users_DeleteByUserId",
                table: "BlogPostComments",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_blogPosts_Users_CreateByUserId",
                table: "blogPosts",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_blogPosts_Users_DeleteByUserId",
                table: "blogPosts",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_Users_CreateByUserId",
                table: "contacts",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_contacts_Users_DeleteByUserId",
                table: "contacts",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_happyClients_Users_CreateByUserId",
                table: "happyClients",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_happyClients_Users_DeleteByUserId",
                table: "happyClients",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_Users_CreateByUserId",
                table: "products",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_products_Users_DeleteByUserId",
                table: "products",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productTypes_Users_CreateByUserId",
                table: "productTypes",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productTypes_Users_DeleteByUserId",
                table: "productTypes",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subscrices_Users_CreateByUserId",
                table: "subscrices",
                column: "CreateByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_subscrices_Users_DeleteByUserId",
                table: "subscrices",
                column: "DeleteByUserId",
                principalSchema: "Membership",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_accountdetails_Users_CreateByUserId",
                table: "accountdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_accountdetails_Users_DeleteByUserId",
                table: "accountdetails");

            migrationBuilder.DropForeignKey(
                name: "FK_auditLogs_Users_CreateByUserId",
                table: "auditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_auditLogs_Users_DeleteByUserId",
                table: "auditLogs");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_Users_CreateByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_BlogPostComments_Users_DeleteByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropForeignKey(
                name: "FK_blogPosts_Users_CreateByUserId",
                table: "blogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_blogPosts_Users_DeleteByUserId",
                table: "blogPosts");

            migrationBuilder.DropForeignKey(
                name: "FK_contacts_Users_CreateByUserId",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_contacts_Users_DeleteByUserId",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_happyClients_Users_CreateByUserId",
                table: "happyClients");

            migrationBuilder.DropForeignKey(
                name: "FK_happyClients_Users_DeleteByUserId",
                table: "happyClients");

            migrationBuilder.DropForeignKey(
                name: "FK_products_Users_CreateByUserId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_products_Users_DeleteByUserId",
                table: "products");

            migrationBuilder.DropForeignKey(
                name: "FK_productTypes_Users_CreateByUserId",
                table: "productTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_productTypes_Users_DeleteByUserId",
                table: "productTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_subscrices_Users_CreateByUserId",
                table: "subscrices");

            migrationBuilder.DropForeignKey(
                name: "FK_subscrices_Users_DeleteByUserId",
                table: "subscrices");

            migrationBuilder.DropIndex(
                name: "IX_subscrices_CreateByUserId",
                table: "subscrices");

            migrationBuilder.DropIndex(
                name: "IX_subscrices_DeleteByUserId",
                table: "subscrices");

            migrationBuilder.DropIndex(
                name: "IX_productTypes_CreateByUserId",
                table: "productTypes");

            migrationBuilder.DropIndex(
                name: "IX_productTypes_DeleteByUserId",
                table: "productTypes");

            migrationBuilder.DropIndex(
                name: "IX_products_CreateByUserId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_DeleteByUserId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_happyClients_CreateByUserId",
                table: "happyClients");

            migrationBuilder.DropIndex(
                name: "IX_happyClients_DeleteByUserId",
                table: "happyClients");

            migrationBuilder.DropIndex(
                name: "IX_contacts_CreateByUserId",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_contacts_DeleteByUserId",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "IX_blogPosts_CreateByUserId",
                table: "blogPosts");

            migrationBuilder.DropIndex(
                name: "IX_blogPosts_DeleteByUserId",
                table: "blogPosts");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostComments_CreateByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropIndex(
                name: "IX_BlogPostComments_DeleteByUserId",
                table: "BlogPostComments");

            migrationBuilder.DropIndex(
                name: "IX_auditLogs_CreateByUserId",
                table: "auditLogs");

            migrationBuilder.DropIndex(
                name: "IX_auditLogs_DeleteByUserId",
                table: "auditLogs");

            migrationBuilder.DropIndex(
                name: "IX_accountdetails_CreateByUserId",
                table: "accountdetails");

            migrationBuilder.DropIndex(
                name: "IX_accountdetails_DeleteByUserId",
                table: "accountdetails");
        }
    }
}

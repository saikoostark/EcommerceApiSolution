using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EcommerceApi.Migrations
{
    /// <inheritdoc />
    public partial class updatemodel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Categorys_CategoryID",
                table: "ProductCategory");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategory_Products_ProductID",
                table: "ProductCategory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory");

            migrationBuilder.RenameTable(
                name: "ProductCategory",
                newName: "ProductCategorys");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_ProductID",
                table: "ProductCategorys",
                newName: "IX_ProductCategorys_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategory_CategoryID",
                table: "ProductCategorys",
                newName: "IX_ProductCategorys_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategorys",
                table: "ProductCategorys",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "tJFJLdAATSIh3dZfQXICY+UG8VMKuGEMHICqabf28jc=", "0QqpIE9VVt3BKCVP7fPlkA==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "HiZ6B+/lMwUx4mRdbMTW2m+TwUB56uWykAgeRai5XwQ=", "yf2KJJZN48NN2wZi4IOMUg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorys_Categorys_CategoryID",
                table: "ProductCategorys",
                column: "CategoryID",
                principalTable: "Categorys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategorys_Products_ProductID",
                table: "ProductCategorys",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorys_Categorys_CategoryID",
                table: "ProductCategorys");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductCategorys_Products_ProductID",
                table: "ProductCategorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductCategorys",
                table: "ProductCategorys");

            migrationBuilder.RenameTable(
                name: "ProductCategorys",
                newName: "ProductCategory");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategorys_ProductID",
                table: "ProductCategory",
                newName: "IX_ProductCategory_ProductID");

            migrationBuilder.RenameIndex(
                name: "IX_ProductCategorys_CategoryID",
                table: "ProductCategory",
                newName: "IX_ProductCategory_CategoryID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductCategory",
                table: "ProductCategory",
                column: "ID");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 1,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "QvKrk+3U4NbWSGEQK6xQs5AZGGMuJry2Q5Got2y33YI=", "+ZoTCC1Hm2mMP6TLkiU/jg==" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "ID",
                keyValue: 2,
                columns: new[] { "HashedPassword", "Salt" },
                values: new object[] { "Q30XmYtVtPwCGC8Y+7EIR8B1XSeKeakvtX3DKtIGDxQ=", "L3+TKH/tC86V/oqNvTXffg==" });

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Categorys_CategoryID",
                table: "ProductCategory",
                column: "CategoryID",
                principalTable: "Categorys",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductCategory_Products_ProductID",
                table: "ProductCategory",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class upconfigcategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_productCategories_CategoryId",
                table: "CategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_productCategories_Languages_LanguageId",
                table: "productCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_productCategories_products_idProduct",
                table: "productCategories");

            migrationBuilder.DropForeignKey(
                name: "FK_productDetails_productCategories_CategoryidCategory",
                table: "productDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategories_productCategories_idCategory",
                table: "ProductInCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_productCategories",
                table: "productCategories");

            migrationBuilder.DropColumn(
                name: "categoryName",
                table: "productCategories");

            migrationBuilder.RenameTable(
                name: "productCategories",
                newName: "Categories");

            migrationBuilder.RenameColumn(
                name: "idProduct",
                table: "Categories",
                newName: "ProductsProductId");

            migrationBuilder.RenameIndex(
                name: "IX_productCategories_LanguageId",
                table: "Categories",
                newName: "IX_Categories_LanguageId");

            migrationBuilder.RenameIndex(
                name: "IX_productCategories_idProduct",
                table: "Categories",
                newName: "IX_Categories_ProductsProductId");

            migrationBuilder.AddColumn<bool>(
                name: "IsShowOnHome",
                table: "Categories",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "SortOrder",
                table: "Categories",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "idCategory");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "idCategory",
                keyValue: 1,
                columns: new[] { "IsShowOnHome", "SortOrder" },
                values: new object[] { true, 1 });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "idCategory",
                keyValue: 2,
                columns: new[] { "IsShowOnHome", "SortOrder" },
                values: new object[] { true, 2 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "decd4715-9839-470c-a5a1-27869dc0aa4d");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "b8740cba-ff87-4b97-bed5-3faf3eb82367", "AQAAAAEAACcQAAAAEN6Dpvuja0YYLcaSyzPEGdb7ck1oOEI6IY6fNP0tLyORi1JSZHqYg3e7jDnejJtLQA==" });

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Languages_LanguageId",
                table: "Categories",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_products_ProductsProductId",
                table: "Categories",
                column: "ProductsProductId",
                principalTable: "products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_Categories_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "idCategory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productDetails_Categories_CategoryidCategory",
                table: "productDetails",
                column: "CategoryidCategory",
                principalTable: "Categories",
                principalColumn: "idCategory",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategories_Categories_idCategory",
                table: "ProductInCategories",
                column: "idCategory",
                principalTable: "Categories",
                principalColumn: "idCategory",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Languages_LanguageId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Categories_products_ProductsProductId",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryTranslations_Categories_CategoryId",
                table: "CategoryTranslations");

            migrationBuilder.DropForeignKey(
                name: "FK_productDetails_Categories_CategoryidCategory",
                table: "productDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductInCategories_Categories_idCategory",
                table: "ProductInCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "IsShowOnHome",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "SortOrder",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "productCategories");

            migrationBuilder.RenameColumn(
                name: "ProductsProductId",
                table: "productCategories",
                newName: "idProduct");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_ProductsProductId",
                table: "productCategories",
                newName: "IX_productCategories_idProduct");

            migrationBuilder.RenameIndex(
                name: "IX_Categories_LanguageId",
                table: "productCategories",
                newName: "IX_productCategories_LanguageId");

            migrationBuilder.AddColumn<string>(
                name: "categoryName",
                table: "productCategories",
                type: "VARCHAR(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_productCategories",
                table: "productCategories",
                column: "idCategory");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "abda05e3-09ec-43fb-b740-975673c29dc5");

            migrationBuilder.UpdateData(
                table: "productCategories",
                keyColumn: "idCategory",
                keyValue: 1,
                column: "categoryName",
                value: "Shoes");

            migrationBuilder.UpdateData(
                table: "productCategories",
                keyColumn: "idCategory",
                keyValue: 2,
                column: "categoryName",
                value: "Shirt");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "dd749c45-1cc9-479d-bd72-0f7db1999c3f", "AQAAAAEAACcQAAAAEFcX/psx36KMGfHWBWTDFk2s4jt7NyzX99lWOU8cUJxrTV9MfkZelTQKz6L8ipvK5w==" });

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryTranslations_productCategories_CategoryId",
                table: "CategoryTranslations",
                column: "CategoryId",
                principalTable: "productCategories",
                principalColumn: "idCategory",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_productCategories_Languages_LanguageId",
                table: "productCategories",
                column: "LanguageId",
                principalTable: "Languages",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productCategories_products_idProduct",
                table: "productCategories",
                column: "idProduct",
                principalTable: "products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_productDetails_productCategories_CategoryidCategory",
                table: "productDetails",
                column: "CategoryidCategory",
                principalTable: "productCategories",
                principalColumn: "idCategory",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductInCategories_productCategories_idCategory",
                table: "ProductInCategories",
                column: "idCategory",
                principalTable: "productCategories",
                principalColumn: "idCategory",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

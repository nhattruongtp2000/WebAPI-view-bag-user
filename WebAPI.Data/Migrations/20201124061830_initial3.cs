using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProductInCategories_idCategory",
                table: "ProductInCategories");

            migrationBuilder.AddColumn<int>(
                name: "productCategoriesidCategory",
                table: "productDetails",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductInCategories",
                table: "ProductInCategories",
                columns: new[] { "idCategory", "idProduct" });

            migrationBuilder.InsertData(
                table: "ProductInCategories",
                columns: new[] { "idCategory", "idProduct" },
                values: new object[] { 1, 1 });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7b1d8cd3-5e88-4002-8901-5b447a05248a");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d06bd459-afbf-4348-82ce-d183a26ea693", "AQAAAAEAACcQAAAAEKbX5Uq0McqgZTiDF1j2G7bOtrhXKZVKfxEBekwLCWvnMXcm/EaLD4/wMg66dz1hVw==" });

            migrationBuilder.CreateIndex(
                name: "IX_productDetails_productCategoriesidCategory",
                table: "productDetails",
                column: "productCategoriesidCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_productDetails_productCategories_productCategoriesidCategory",
                table: "productDetails",
                column: "productCategoriesidCategory",
                principalTable: "productCategories",
                principalColumn: "idCategory",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productDetails_productCategories_productCategoriesidCategory",
                table: "productDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductInCategories",
                table: "ProductInCategories");

            migrationBuilder.DropIndex(
                name: "IX_productDetails_productCategoriesidCategory",
                table: "productDetails");

            migrationBuilder.DeleteData(
                table: "ProductInCategories",
                keyColumns: new[] { "idCategory", "idProduct" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DropColumn(
                name: "productCategoriesidCategory",
                table: "productDetails");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7f069f94-e3ee-4ce6-a91d-90f96c7718a6");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "0608dff2-417a-46f1-9277-421f4976f9fa", "AQAAAAEAACcQAAAAEAvddmZS1Obby49t8EOcetdSEmJq1ntds5fvXFfWFVXEdqeUvf/lW+USv+VAw4j5OQ==" });

            migrationBuilder.CreateIndex(
                name: "IX_ProductInCategories_idCategory",
                table: "ProductInCategories",
                column: "idCategory");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class dd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_products_ProductsProductId",
                table: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_Categories_ProductsProductId",
                table: "Categories");

            migrationBuilder.DropColumn(
                name: "ProductsProductId",
                table: "Categories");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "f321676e-3060-4f38-b0f7-dd190ef1a593");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a2dd5df0-c86c-4d1e-9267-f470ffbfc47a", "AQAAAAEAACcQAAAAEELk/sMiVX4/kUlcUxgWkaMaU2hax/EthbkE5kATfB/AxjPWdcR+rXpAJXrZnXpthA==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProductsProductId",
                table: "Categories",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Categories_ProductsProductId",
                table: "Categories",
                column: "ProductsProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_products_ProductsProductId",
                table: "Categories",
                column: "ProductsProductId",
                principalTable: "products",
                principalColumn: "ProductId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

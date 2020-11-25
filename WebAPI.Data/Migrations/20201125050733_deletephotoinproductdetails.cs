using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class deletephotoinproductdetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_productPhotos_productDetails_productDetailidProductDetail",
                table: "productPhotos");

            migrationBuilder.DropIndex(
                name: "IX_productPhotos_productDetailidProductDetail",
                table: "productPhotos");

            migrationBuilder.DropColumn(
                name: "productDetailidProductDetail",
                table: "productPhotos");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "81ab4243-adcc-49a5-af55-9064cebcff30");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "6e43ffa3-7689-4f78-b29e-46b15a7ae447", "AQAAAAEAACcQAAAAEPfotnok9mfSbUBssgTduaMfZwTbcDS1kLyPy/FgR/Mbwypa12BS1WIaBrr8MEiyXw==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "productDetailidProductDetail",
                table: "productPhotos",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "a71a52f2-9e1e-4cdb-b20c-898d6d1498d4");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "e07cc706-e484-4583-9280-8e9f3df61525", "AQAAAAEAACcQAAAAEN853eAlymzfFslK2dyN3x7Wt+NBA/w6zpYgEVPSpSkWEme8MgVrWfpoxMP0/sTBDw==" });

            migrationBuilder.CreateIndex(
                name: "IX_productPhotos_productDetailidProductDetail",
                table: "productPhotos",
                column: "productDetailidProductDetail");

            migrationBuilder.AddForeignKey(
                name: "FK_productPhotos_productDetails_productDetailidProductDetail",
                table: "productPhotos",
                column: "productDetailidProductDetail",
                principalTable: "productDetails",
                principalColumn: "idProductDetail",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

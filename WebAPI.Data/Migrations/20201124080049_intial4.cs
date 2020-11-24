using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class intial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "idCategory",
                table: "products");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "4ea992d0-b05a-42ef-a570-03ae02d77510");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "8bbfface-505e-46a5-be06-8f39f754d9f0", "AQAAAAEAACcQAAAAEFHCoVSq/DlUwLwhUKPNm3Azju2Wq7eisYZ19Q2oOS2K+E4X9thP0gEwEoBOexk72w==" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "idCategory",
                table: "products",
                type: "VARCHAR(200)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "7b1d8cd3-5e88-4002-8901-5b447a05248a");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "idProduct",
                keyValue: 1,
                column: "idCategory",
                value: "1");

            migrationBuilder.UpdateData(
                table: "products",
                keyColumn: "idProduct",
                keyValue: 2,
                column: "idCategory",
                value: "1");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "d06bd459-afbf-4348-82ce-d183a26ea693", "AQAAAAEAACcQAAAAEKbX5Uq0McqgZTiDF1j2G7bOtrhXKZVKfxEBekwLCWvnMXcm/EaLD4/wMg66dz1hVw==" });
        }
    }
}

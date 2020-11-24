using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Data.Migrations
{
    public partial class addlanguages : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: new Guid("8d04dce2-969a-435d-bba4-df3f325983dc"),
                column: "ConcurrencyStamp",
                value: "1245b067-03e1-4ae0-b357-10654fbe9f81");

            migrationBuilder.UpdateData(
                table: "users",
                keyColumn: "Id",
                keyValue: new Guid("69bd714f-9576-45ba-b5b7-f00649be00de"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "db43f881-deeb-44ec-84e7-d347848daae5", "AQAAAAEAACcQAAAAEEOx6DkokexR8Gx4TwEZ8vuTjADu4fGLILs7LSaOqtSLVglvgBG5yZwSYfbazScRNg==" });
        }
    }
}

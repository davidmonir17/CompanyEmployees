using Microsoft.EntityFrameworkCore.Migrations;

namespace CompanyEmployee.Migrations
{
    public partial class AddRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "221bd657-036c-4c74-8697-53d955190f76", "b783987a-b79c-4fd5-b8d1-047cd635cea3", "Manager", "MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "6140c004-c553-4c4a-a7f7-e61393002945", "12469ff6-d2d8-4f39-9b84-31d80c64403e", "Administrator", "ADMINISTRATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "221bd657-036c-4c74-8697-53d955190f76");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6140c004-c553-4c4a-a7f7-e61393002945");
        }
    }
}

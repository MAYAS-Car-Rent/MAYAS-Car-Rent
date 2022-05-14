using Microsoft.EntityFrameworkCore.Migrations;

namespace MAYAS_Car_Rent.Migrations
{
    public partial class addsomeedit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cars",
                keyColumn: "Id",
                keyValue: 4);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "CompanyId", "CustomerId", "IsRent", "Model", "Name", "PlateNumber", "Year" },
                values: new object[,]
                {
                    { 1, "Red", 0, 0, false, "sportage", "KIA", "Jo-12-1234", 2022 },
                    { 2, "Black", 0, 0, false, "m3", "BMW", "Jo-13-123", 2022 },
                    { 3, "Blue", 0, 0, false, "corolla", "Toyota", "Jo-14-24685", 2022 },
                    { 4, "White", 0, 0, false, "G-Class", "Mercedes", "Jo-10-10", 2022 }
                });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace MAYAS_Car_Rent.Migrations
{
    public partial class AddModeling : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Admins",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "MAYAS_Admin@Gmail.com", "Admin", "Admin123" });

            migrationBuilder.InsertData(
                table: "Cars",
                columns: new[] { "Id", "Color", "CompanyId", "CustomerId", "IsRent", "Model", "Name", "PlateNumber", "Year" },
                values: new object[,]
                {
                    { 1, "Red", null, null, false, "sportage", "KIA", "Jo-12-1234", 2022 },
                    { 2, "Black", null, null, false, "m3", "BMW", "Jo-13-123", 2022 },
                    { 3, "Blue", null, null, false, "corolla", "Toyota", "Jo-14-24685", 2022 },
                    { 4, "White", null, null, false, "G-Class", "Mercedes", "Jo-10-10", 2022 }
                });

            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "Address", "CommercialRegistrationNumber", "Email", "Password", "PhoneNumber", "UserName" },
                values: new object[,]
                {
                    { 1, "Amman", 123456789, "SultanRental@Gmail.com", "Sultan123", "962791234567", "Sultan Rental" },
                    { 2, "Irbid", 123456789, "OlaRental@Gmail.com", "Ola123", "962791234567", "Ola Rental" },
                    { 3, "Jarash", 123456789, "HaneenRental@Gmail.com", "Haneen123", "962791234567", "Haneen Rental" },
                    { 4, "Amman", 123456789, "AbdalrahmanRental@Gmail.com", "Abdalrahman123", "962791234567", "Abdalrahman Rental" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Admins",
                keyColumn: "Id",
                keyValue: 1);

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

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}

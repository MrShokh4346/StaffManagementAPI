using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace StaffManagement.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedFirstData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Staffs",
                columns: new[] { "Id", "Department", "Email", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, 2, "nodir@gmail.com", "Nodir", "Qodirov" },
                    { 2, 3, "akbar@gmail.com", "Akbar", "Bozorov" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staffs",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

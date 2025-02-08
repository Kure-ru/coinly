using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace coinly.Migrations
{
    /// <inheritdoc />
    public partial class SeedAccountsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Accounts",
                columns: new[] { "id", "balance", "expense", "income" },
                values: new object[,]
                {
                    { 1, 4000f, 6000f, 10000f },
                    { 2, 10000f, 10000f, 20000f },
                    { 3, 10000f, 20000f, 30000f }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Accounts",
                keyColumn: "id",
                keyValue: 3);
        }
    }
}

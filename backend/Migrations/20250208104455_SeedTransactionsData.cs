using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace coinly.Migrations
{
    /// <inheritdoc />
    public partial class SeedTransactionsData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "id", "accountId", "amount", "category", "merchant" },
                values: new object[,]
                {
                    { 1, 1, 1000f, "rent", "landlord" },
                    { 2, 1, 2000f, "groceries", "monoprix" },
                    { 3, 1, 3000f, "salary", "employer" },
                    { 4, 2, 4000f, "rent", "landlord" },
                    { 5, 2, 5000f, "groceries", "monoprix" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "id",
                keyValue: 5);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Catalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedAt", "Name", "UpdatedAt" },
                values: new object[,]
                {
                    { new Guid("58a45108-6fb5-410c-92a2-3ca63081be2c"), new DateTime(2025, 4, 22, 23, 38, 28, 0, DateTimeKind.Utc), "Eletrônicos", null },
                    { new Guid("9a2342ca-61bd-421e-ba39-0d66f999e7f6"), new DateTime(2025, 4, 22, 23, 38, 28, 0, DateTimeKind.Utc), "Livros", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("58a45108-6fb5-410c-92a2-3ca63081be2c"));

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: new Guid("9a2342ca-61bd-421e-ba39-0d66f999e7f6"));
        }
    }
}

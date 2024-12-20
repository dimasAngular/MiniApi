using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class SeedVillaTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Villas",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, " ", new DateTime(2024, 12, 15, 18, 48, 43, 569, DateTimeKind.Local).AddTicks(1071), "lorem", " ", "Royal Villa", 4, 200.0, 500, new DateTime(2024, 12, 15, 18, 48, 43, 570, DateTimeKind.Local).AddTicks(8309) },
                    { 2, " ", new DateTime(2024, 12, 15, 18, 48, 43, 570, DateTimeKind.Local).AddTicks(8690), "lorem", " ", "Villa-Vip", 6, 500.0, 700, new DateTime(2024, 12, 15, 18, 48, 43, 570, DateTimeKind.Local).AddTicks(8692) },
                    { 3, " ", new DateTime(2024, 12, 15, 18, 48, 43, 570, DateTimeKind.Local).AddTicks(8694), "lorem", " ", "Royal-Wild", 4, 300.0, 500, new DateTime(2024, 12, 15, 18, 48, 43, 570, DateTimeKind.Local).AddTicks(8695) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Villas",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}

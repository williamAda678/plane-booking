using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FlightBooking.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedSampleData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Aircraft",
                columns: new[] { "Id", "Model", "Registration", "SeatCapacity" },
                values: new object[,]
                {
                    { new Guid("44444444-4444-4444-4444-444444444444"), "Airbus A320", "VH-ABC", 180 },
                    { new Guid("55555555-5555-5555-5555-555555555555"), "Boeing 787-9", "VH-XYZ", 296 }
                });

            migrationBuilder.InsertData(
                table: "Airports",
                columns: new[] { "Id", "City", "Code", "Country", "Name" },
                values: new object[,]
                {
                    { new Guid("11111111-1111-1111-1111-111111111111"), "Sydney", "SYD", "Australia", "Sydney Kingsford Smith" },
                    { new Guid("22222222-2222-2222-2222-222222222222"), "Tokyo", "HND", "Japan", "Tokyo Haneda" },
                    { new Guid("33333333-3333-3333-3333-333333333333"), "Singapore", "SIN", "Singapore", "Singapore Changi" }
                });

            migrationBuilder.InsertData(
                table: "Flights",
                columns: new[] { "Id", "AircraftId", "ArrivalAirportId", "ArrivalTime", "DepartureAirportId", "DepartureTime", "FlightNumber", "Price" },
                values: new object[,]
                {
                    { new Guid("66666666-6666-6666-6666-666666666666"), new Guid("55555555-5555-5555-5555-555555555555"), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2027, 3, 15, 18, 0, 0, 0, DateTimeKind.Utc), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2027, 3, 15, 10, 0, 0, 0, DateTimeKind.Utc), "FB101", 850m },
                    { new Guid("77777777-7777-7777-7777-777777777777"), new Guid("44444444-4444-4444-4444-444444444444"), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2027, 3, 16, 10, 0, 0, 0, DateTimeKind.Utc), new Guid("22222222-2222-2222-2222-222222222222"), new DateTime(2027, 3, 16, 2, 0, 0, 0, DateTimeKind.Utc), "FB202", 420m },
                    { new Guid("88888888-8888-8888-8888-888888888888"), new Guid("55555555-5555-5555-5555-555555555555"), new Guid("11111111-1111-1111-1111-111111111111"), new DateTime(2027, 3, 18, 18, 0, 0, 0, DateTimeKind.Utc), new Guid("33333333-3333-3333-3333-333333333333"), new DateTime(2027, 3, 18, 12, 0, 0, 0, DateTimeKind.Utc), "FB303", 610m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("66666666-6666-6666-6666-666666666666"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("77777777-7777-7777-7777-777777777777"));

            migrationBuilder.DeleteData(
                table: "Flights",
                keyColumn: "Id",
                keyValue: new Guid("88888888-8888-8888-8888-888888888888"));

            migrationBuilder.DeleteData(
                table: "Aircraft",
                keyColumn: "Id",
                keyValue: new Guid("44444444-4444-4444-4444-444444444444"));

            migrationBuilder.DeleteData(
                table: "Aircraft",
                keyColumn: "Id",
                keyValue: new Guid("55555555-5555-5555-5555-555555555555"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: new Guid("11111111-1111-1111-1111-111111111111"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: new Guid("22222222-2222-2222-2222-222222222222"));

            migrationBuilder.DeleteData(
                table: "Airports",
                keyColumn: "Id",
                keyValue: new Guid("33333333-3333-3333-3333-333333333333"));
        }
    }
}

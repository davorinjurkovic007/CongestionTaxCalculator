using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CongestionTaxCalculator.Data.Migrations
{
    public partial class initialization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SingleChargeRule = table.Column<bool>(type: "bit", nullable: false),
                    PeakSeason = table.Column<bool>(type: "bit", nullable: false),
                    MaxDayOffPeakSeason = table.Column<int>(type: "int", nullable: false),
                    MaxDayPeakSeason = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FreeOfChargeDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FreeOfChargeDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FreeOfChargeDays_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PeakDays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    PeakBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PeakEnd = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PeakDays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PeakDays_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TaxAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CityId = table.Column<int>(type: "int", nullable: false),
                    TimeIn = table.Column<TimeSpan>(type: "time", nullable: false),
                    TimeOut = table.Column<TimeSpan>(type: "time", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    PeakSeason = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaxAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TaxAmounts_Cities_CityId",
                        column: x => x.CityId,
                        principalTable: "Cities",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "MaxDayOffPeakSeason", "MaxDayPeakSeason", "Name", "PeakSeason", "SingleChargeRule" },
                values: new object[] { 1, 60, 60, "Gothenburg", false, true });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "MaxDayOffPeakSeason", "MaxDayPeakSeason", "Name", "PeakSeason", "SingleChargeRule" },
                values: new object[] { 2, 105, 135, "Stockholm", true, false });

            migrationBuilder.InsertData(
                table: "FreeOfChargeDays",
                columns: new[] { "Id", "CityId", "Date" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 75, 2, new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 74, 2, new DateTime(2013, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 73, 2, new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 72, 2, new DateTime(2013, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 71, 2, new DateTime(2013, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 70, 2, new DateTime(2013, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 69, 2, new DateTime(2013, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 68, 2, new DateTime(2013, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 67, 2, new DateTime(2013, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 66, 2, new DateTime(2013, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 65, 2, new DateTime(2013, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 64, 2, new DateTime(2013, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 63, 2, new DateTime(2013, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 62, 2, new DateTime(2013, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 61, 2, new DateTime(2013, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 60, 2, new DateTime(2013, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 58, 2, new DateTime(2013, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 57, 2, new DateTime(2013, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 56, 2, new DateTime(2013, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 55, 2, new DateTime(2013, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 54, 2, new DateTime(2013, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 76, 2, new DateTime(2013, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 77, 2, new DateTime(2013, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 78, 2, new DateTime(2013, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 79, 2, new DateTime(2013, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 101, 2, new DateTime(2013, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 100, 2, new DateTime(2013, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 99, 2, new DateTime(2013, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 98, 2, new DateTime(2013, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 97, 2, new DateTime(2013, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 96, 2, new DateTime(2013, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 95, 2, new DateTime(2013, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 94, 2, new DateTime(2013, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 93, 2, new DateTime(2013, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 92, 2, new DateTime(2013, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 53, 1, new DateTime(2013, 7, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 91, 2, new DateTime(2013, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 89, 2, new DateTime(2013, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 88, 2, new DateTime(2013, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 87, 2, new DateTime(2013, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 86, 2, new DateTime(2013, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "FreeOfChargeDays",
                columns: new[] { "Id", "CityId", "Date" },
                values: new object[,]
                {
                    { 85, 2, new DateTime(2013, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 84, 2, new DateTime(2013, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 83, 2, new DateTime(2013, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 82, 2, new DateTime(2013, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 81, 2, new DateTime(2013, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 80, 2, new DateTime(2013, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 90, 2, new DateTime(2013, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 52, 1, new DateTime(2013, 7, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 59, 2, new DateTime(2013, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 50, 1, new DateTime(2013, 7, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 29, 1, new DateTime(2013, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 28, 1, new DateTime(2013, 7, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 27, 1, new DateTime(2013, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 26, 1, new DateTime(2013, 7, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 25, 1, new DateTime(2013, 7, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 24, 1, new DateTime(2013, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 23, 1, new DateTime(2013, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, 1, new DateTime(2013, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, 1, new DateTime(2013, 12, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, 1, new DateTime(2013, 12, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, 1, new DateTime(2013, 12, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 51, 1, new DateTime(2013, 7, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, 1, new DateTime(2013, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 30, 1, new DateTime(2013, 7, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, 1, new DateTime(2013, 6, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, 1, new DateTime(2013, 6, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, 1, new DateTime(2013, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, 1, new DateTime(2013, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, 1, new DateTime(2013, 5, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, 1, new DateTime(2013, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, 1, new DateTime(2013, 4, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, 1, new DateTime(2013, 4, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, 1, new DateTime(2013, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, 1, new DateTime(2013, 3, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, 1, new DateTime(2013, 3, 29, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, 1, new DateTime(2013, 3, 28, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, 1, new DateTime(2013, 1, 6, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, 1, new DateTime(2013, 1, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, 1, new DateTime(2013, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 31, 1, new DateTime(2013, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, 1, new DateTime(2013, 11, 2, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 33, 1, new DateTime(2013, 7, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "FreeOfChargeDays",
                columns: new[] { "Id", "CityId", "Date" },
                values: new object[,]
                {
                    { 32, 1, new DateTime(2013, 7, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 48, 1, new DateTime(2013, 7, 26, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 47, 1, new DateTime(2013, 7, 25, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 46, 1, new DateTime(2013, 7, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 45, 1, new DateTime(2013, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 44, 1, new DateTime(2013, 7, 22, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 43, 1, new DateTime(2013, 7, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 42, 1, new DateTime(2013, 7, 20, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 49, 1, new DateTime(2013, 7, 27, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 40, 1, new DateTime(2013, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 39, 1, new DateTime(2013, 7, 17, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 38, 1, new DateTime(2013, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 37, 1, new DateTime(2013, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 36, 1, new DateTime(2013, 7, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 35, 1, new DateTime(2013, 7, 13, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 41, 1, new DateTime(2013, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 34, 1, new DateTime(2013, 7, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "PeakDays",
                columns: new[] { "Id", "CityId", "PeakBegin", "PeakEnd" },
                values: new object[,]
                {
                    { 2, 2, new DateTime(2013, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 1, 2, new DateTime(2013, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2013, 6, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "TaxAmounts",
                columns: new[] { "Id", "Amount", "CityId", "PeakSeason", "TimeIn", "TimeOut" },
                values: new object[,]
                {
                    { 21, 45, 2, true, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 17, 30, 0, 0) },
                    { 22, 30, 2, true, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 18, 0, 0, 0) },
                    { 23, 20, 2, true, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 18, 30, 0, 0) },
                    { 24, 0, 2, true, new TimeSpan(0, 18, 30, 0, 0), new TimeSpan(0, 0, 0, 0, 0) },
                    { 25, 0, 2, false, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 6, 0, 0, 0) },
                    { 28, 35, 2, false, new TimeSpan(0, 7, 0, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 27, 25, 2, false, new TimeSpan(0, 6, 30, 0, 0), new TimeSpan(0, 7, 0, 0, 0) },
                    { 20, 30, 2, true, new TimeSpan(0, 15, 30, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { 29, 25, 2, false, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 30, 15, 2, false, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 31, 11, 2, false, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 32, 15, 2, false, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 15, 30, 0, 0) },
                    { 33, 25, 2, false, new TimeSpan(0, 15, 30, 0, 0), new TimeSpan(0, 16, 0, 0, 0) },
                    { 34, 35, 2, false, new TimeSpan(0, 16, 0, 0, 0), new TimeSpan(0, 17, 30, 0, 0) },
                    { 35, 25, 2, false, new TimeSpan(0, 17, 30, 0, 0), new TimeSpan(0, 18, 0, 0, 0) },
                    { 26, 15, 2, false, new TimeSpan(0, 6, 0, 0, 0), new TimeSpan(0, 6, 30, 0, 0) },
                    { 19, 20, 2, true, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 15, 30, 0, 0) },
                    { 14, 30, 2, true, new TimeSpan(0, 6, 30, 0, 0), new TimeSpan(0, 7, 0, 0, 0) },
                    { 17, 20, 2, true, new TimeSpan(0, 9, 0, 0, 0), new TimeSpan(0, 9, 30, 0, 0) },
                    { 36, 15, 2, false, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 18, 30, 0, 0) },
                    { 11, 0, 1, false, new TimeSpan(0, 18, 30, 0, 0), new TimeSpan(0, 0, 0, 0, 0) },
                    { 10, 9, 1, false, new TimeSpan(0, 18, 0, 0, 0), new TimeSpan(0, 18, 30, 0, 0) },
                    { 9, 16, 1, false, new TimeSpan(0, 17, 0, 0, 0), new TimeSpan(0, 18, 0, 0, 0) }
                });

            migrationBuilder.InsertData(
                table: "TaxAmounts",
                columns: new[] { "Id", "Amount", "CityId", "PeakSeason", "TimeIn", "TimeOut" },
                values: new object[,]
                {
                    { 8, 22, 1, false, new TimeSpan(0, 15, 30, 0, 0), new TimeSpan(0, 17, 0, 0, 0) },
                    { 7, 16, 1, false, new TimeSpan(0, 15, 0, 0, 0), new TimeSpan(0, 15, 30, 0, 0) },
                    { 6, 9, 1, false, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 18, 11, 2, true, new TimeSpan(0, 9, 30, 0, 0), new TimeSpan(0, 15, 0, 0, 0) },
                    { 5, 16, 1, false, new TimeSpan(0, 8, 0, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 3, 16, 1, false, new TimeSpan(0, 6, 30, 0, 0), new TimeSpan(0, 7, 0, 0, 0) },
                    { 2, 9, 1, false, new TimeSpan(0, 6, 0, 0, 0), new TimeSpan(0, 6, 30, 0, 0) },
                    { 1, 0, 1, false, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 6, 0, 0, 0) },
                    { 12, 0, 2, true, new TimeSpan(0, 0, 0, 0, 0), new TimeSpan(0, 6, 0, 0, 0) },
                    { 13, 15, 2, true, new TimeSpan(0, 6, 0, 0, 0), new TimeSpan(0, 6, 30, 0, 0) },
                    { 15, 45, 2, true, new TimeSpan(0, 7, 0, 0, 0), new TimeSpan(0, 8, 30, 0, 0) },
                    { 16, 30, 2, true, new TimeSpan(0, 8, 30, 0, 0), new TimeSpan(0, 9, 0, 0, 0) },
                    { 4, 22, 1, false, new TimeSpan(0, 7, 0, 0, 0), new TimeSpan(0, 8, 0, 0, 0) },
                    { 37, 0, 2, false, new TimeSpan(0, 18, 30, 0, 0), new TimeSpan(0, 0, 0, 0, 0) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_FreeOfChargeDays_CityId",
                table: "FreeOfChargeDays",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_PeakDays_CityId",
                table: "PeakDays",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaxAmounts_CityId",
                table: "TaxAmounts",
                column: "CityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FreeOfChargeDays");

            migrationBuilder.DropTable(
                name: "PeakDays");

            migrationBuilder.DropTable(
                name: "TaxAmounts");

            migrationBuilder.DropTable(
                name: "Cities");
        }
    }
}

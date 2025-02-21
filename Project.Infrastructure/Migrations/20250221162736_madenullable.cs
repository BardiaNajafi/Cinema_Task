using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class madenullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShowTimes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 2, 21, 20, 27, 35, 700, DateTimeKind.Utc).AddTicks(1276), new DateTime(2025, 2, 21, 18, 27, 35, 700, DateTimeKind.Utc).AddTicks(1270) });

            migrationBuilder.UpdateData(
                table: "ShowTimes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 2, 21, 21, 27, 35, 700, DateTimeKind.Utc).AddTicks(1279), new DateTime(2025, 2, 21, 19, 27, 35, 700, DateTimeKind.Utc).AddTicks(1278) });

            migrationBuilder.UpdateData(
                table: "ShowTimes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 2, 21, 22, 27, 35, 700, DateTimeKind.Utc).AddTicks(1280), new DateTime(2025, 2, 21, 20, 27, 35, 700, DateTimeKind.Utc).AddTicks(1280) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ShowTimes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 2, 21, 18, 26, 12, 841, DateTimeKind.Utc).AddTicks(2976), new DateTime(2025, 2, 21, 16, 26, 12, 841, DateTimeKind.Utc).AddTicks(2971) });

            migrationBuilder.UpdateData(
                table: "ShowTimes",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 2, 21, 19, 26, 12, 841, DateTimeKind.Utc).AddTicks(2979), new DateTime(2025, 2, 21, 17, 26, 12, 841, DateTimeKind.Utc).AddTicks(2978) });

            migrationBuilder.UpdateData(
                table: "ShowTimes",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2025, 2, 21, 20, 26, 12, 841, DateTimeKind.Utc).AddTicks(2980), new DateTime(2025, 2, 21, 18, 26, 12, 841, DateTimeKind.Utc).AddTicks(2980) });
        }
    }
}

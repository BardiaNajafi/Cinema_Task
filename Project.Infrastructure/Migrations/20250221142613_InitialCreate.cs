using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Project.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    PosterUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Row = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RoomId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seats_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ShowTimes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovieId = table.Column<int>(type: "int", nullable: false),
                    RoomId = table.Column<int>(type: "int", nullable: false),
                    StartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShowTimes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShowTimes_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShowTimes_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Bookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShowTimeId = table.Column<int>(type: "int", nullable: false),
                    SeatId = table.Column<int>(type: "int", nullable: false),
                    BookedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookings_Seats_SeatId",
                        column: x => x.SeatId,
                        principalTable: "Seats",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Bookings_ShowTimes_ShowTimeId",
                        column: x => x.ShowTimeId,
                        principalTable: "ShowTimes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "PosterUrl", "Title" },
                values: new object[,]
                {
                    { 1, "https://movie.com/Lalaland.jpg", "La La Land" },
                    { 2, "https://movie.com/Inception.jpg", "Inception" },
                    { 3, "https://movie.com/Titanic.jpg", "Titanic" }
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Orange Room" },
                    { 2, "Blue Room" },
                    { 3, "Red Room" }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "Id", "Number", "RoomId", "Row" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 1, 1 },
                    { 3, 3, 1, 1 },
                    { 4, 4, 1, 1 },
                    { 5, 5, 1, 1 },
                    { 6, 6, 1, 1 },
                    { 7, 7, 1, 1 },
                    { 8, 8, 1, 1 },
                    { 9, 1, 1, 2 },
                    { 10, 2, 1, 2 },
                    { 11, 3, 1, 2 },
                    { 12, 4, 1, 2 },
                    { 13, 5, 1, 2 },
                    { 14, 6, 1, 2 },
                    { 15, 7, 1, 2 },
                    { 16, 8, 1, 2 },
                    { 17, 1, 1, 3 },
                    { 18, 2, 1, 3 },
                    { 19, 3, 1, 3 },
                    { 20, 4, 1, 3 },
                    { 21, 5, 1, 3 },
                    { 22, 6, 1, 3 },
                    { 23, 7, 1, 3 },
                    { 24, 8, 1, 3 },
                    { 25, 1, 1, 4 },
                    { 26, 2, 1, 4 },
                    { 27, 3, 1, 4 },
                    { 28, 4, 1, 4 },
                    { 29, 5, 1, 4 },
                    { 30, 6, 1, 4 },
                    { 31, 7, 1, 4 },
                    { 32, 8, 1, 4 },
                    { 33, 1, 1, 5 },
                    { 34, 2, 1, 5 },
                    { 35, 3, 1, 5 },
                    { 36, 4, 1, 5 },
                    { 37, 5, 1, 5 },
                    { 38, 6, 1, 5 },
                    { 39, 7, 1, 5 },
                    { 40, 8, 1, 5 },
                    { 41, 1, 1, 6 },
                    { 42, 2, 1, 6 },
                    { 43, 3, 1, 6 },
                    { 44, 4, 1, 6 },
                    { 45, 5, 1, 6 },
                    { 46, 6, 1, 6 },
                    { 47, 7, 1, 6 },
                    { 48, 8, 1, 6 },
                    { 49, 1, 1, 7 },
                    { 50, 2, 1, 7 },
                    { 51, 3, 1, 7 },
                    { 52, 4, 1, 7 },
                    { 53, 5, 1, 7 },
                    { 54, 6, 1, 7 },
                    { 55, 7, 1, 7 },
                    { 56, 8, 1, 7 },
                    { 57, 1, 1, 8 },
                    { 58, 2, 1, 8 },
                    { 59, 3, 1, 8 },
                    { 60, 4, 1, 8 },
                    { 61, 5, 1, 8 },
                    { 62, 6, 1, 8 },
                    { 63, 7, 1, 8 },
                    { 64, 8, 1, 8 },
                    { 65, 1, 1, 9 },
                    { 66, 2, 1, 9 },
                    { 67, 3, 1, 9 },
                    { 68, 4, 1, 9 },
                    { 69, 5, 1, 9 },
                    { 70, 6, 1, 9 },
                    { 71, 7, 1, 9 },
                    { 72, 8, 1, 9 },
                    { 73, 1, 1, 10 },
                    { 74, 2, 1, 10 },
                    { 75, 3, 1, 10 },
                    { 76, 4, 1, 10 },
                    { 77, 5, 1, 10 },
                    { 78, 6, 1, 10 },
                    { 79, 7, 1, 10 },
                    { 80, 8, 1, 10 },
                    { 81, 1, 2, 1 },
                    { 82, 2, 2, 1 },
                    { 83, 3, 2, 1 },
                    { 84, 4, 2, 1 },
                    { 85, 5, 2, 1 },
                    { 86, 6, 2, 1 },
                    { 87, 7, 2, 1 },
                    { 88, 8, 2, 1 },
                    { 89, 1, 2, 2 },
                    { 90, 2, 2, 2 },
                    { 91, 3, 2, 2 },
                    { 92, 4, 2, 2 },
                    { 93, 5, 2, 2 },
                    { 94, 6, 2, 2 },
                    { 95, 7, 2, 2 },
                    { 96, 8, 2, 2 },
                    { 97, 1, 2, 3 },
                    { 98, 2, 2, 3 },
                    { 99, 3, 2, 3 },
                    { 100, 4, 2, 3 },
                    { 101, 5, 2, 3 },
                    { 102, 6, 2, 3 },
                    { 103, 7, 2, 3 },
                    { 104, 8, 2, 3 },
                    { 105, 1, 2, 4 },
                    { 106, 2, 2, 4 },
                    { 107, 3, 2, 4 },
                    { 108, 4, 2, 4 },
                    { 109, 5, 2, 4 },
                    { 110, 6, 2, 4 },
                    { 111, 7, 2, 4 },
                    { 112, 8, 2, 4 },
                    { 113, 1, 2, 5 },
                    { 114, 2, 2, 5 },
                    { 115, 3, 2, 5 },
                    { 116, 4, 2, 5 },
                    { 117, 5, 2, 5 },
                    { 118, 6, 2, 5 },
                    { 119, 7, 2, 5 },
                    { 120, 8, 2, 5 },
                    { 121, 1, 2, 6 },
                    { 122, 2, 2, 6 },
                    { 123, 3, 2, 6 },
                    { 124, 4, 2, 6 },
                    { 125, 5, 2, 6 },
                    { 126, 6, 2, 6 },
                    { 127, 7, 2, 6 },
                    { 128, 8, 2, 6 },
                    { 129, 1, 2, 7 },
                    { 130, 2, 2, 7 },
                    { 131, 3, 2, 7 },
                    { 132, 4, 2, 7 },
                    { 133, 5, 2, 7 },
                    { 134, 6, 2, 7 },
                    { 135, 7, 2, 7 },
                    { 136, 8, 2, 7 },
                    { 137, 1, 2, 8 },
                    { 138, 2, 2, 8 },
                    { 139, 3, 2, 8 },
                    { 140, 4, 2, 8 },
                    { 141, 5, 2, 8 },
                    { 142, 6, 2, 8 },
                    { 143, 7, 2, 8 },
                    { 144, 8, 2, 8 },
                    { 145, 1, 2, 9 },
                    { 146, 2, 2, 9 },
                    { 147, 3, 2, 9 },
                    { 148, 4, 2, 9 },
                    { 149, 5, 2, 9 },
                    { 150, 6, 2, 9 },
                    { 151, 7, 2, 9 },
                    { 152, 8, 2, 9 },
                    { 153, 1, 2, 10 },
                    { 154, 2, 2, 10 },
                    { 155, 3, 2, 10 },
                    { 156, 4, 2, 10 },
                    { 157, 5, 2, 10 },
                    { 158, 6, 2, 10 },
                    { 159, 7, 2, 10 },
                    { 160, 8, 2, 10 },
                    { 161, 1, 3, 1 },
                    { 162, 2, 3, 1 },
                    { 163, 3, 3, 1 },
                    { 164, 4, 3, 1 },
                    { 165, 5, 3, 1 },
                    { 166, 6, 3, 1 },
                    { 167, 7, 3, 1 },
                    { 168, 8, 3, 1 },
                    { 169, 1, 3, 2 },
                    { 170, 2, 3, 2 },
                    { 171, 3, 3, 2 },
                    { 172, 4, 3, 2 },
                    { 173, 5, 3, 2 },
                    { 174, 6, 3, 2 },
                    { 175, 7, 3, 2 },
                    { 176, 8, 3, 2 },
                    { 177, 1, 3, 3 },
                    { 178, 2, 3, 3 },
                    { 179, 3, 3, 3 },
                    { 180, 4, 3, 3 },
                    { 181, 5, 3, 3 },
                    { 182, 6, 3, 3 },
                    { 183, 7, 3, 3 },
                    { 184, 8, 3, 3 },
                    { 185, 1, 3, 4 },
                    { 186, 2, 3, 4 },
                    { 187, 3, 3, 4 },
                    { 188, 4, 3, 4 },
                    { 189, 5, 3, 4 },
                    { 190, 6, 3, 4 },
                    { 191, 7, 3, 4 },
                    { 192, 8, 3, 4 },
                    { 193, 1, 3, 5 },
                    { 194, 2, 3, 5 },
                    { 195, 3, 3, 5 },
                    { 196, 4, 3, 5 },
                    { 197, 5, 3, 5 },
                    { 198, 6, 3, 5 },
                    { 199, 7, 3, 5 },
                    { 200, 8, 3, 5 },
                    { 201, 1, 3, 6 },
                    { 202, 2, 3, 6 },
                    { 203, 3, 3, 6 },
                    { 204, 4, 3, 6 },
                    { 205, 5, 3, 6 },
                    { 206, 6, 3, 6 },
                    { 207, 7, 3, 6 },
                    { 208, 8, 3, 6 },
                    { 209, 1, 3, 7 },
                    { 210, 2, 3, 7 },
                    { 211, 3, 3, 7 },
                    { 212, 4, 3, 7 },
                    { 213, 5, 3, 7 },
                    { 214, 6, 3, 7 },
                    { 215, 7, 3, 7 },
                    { 216, 8, 3, 7 },
                    { 217, 1, 3, 8 },
                    { 218, 2, 3, 8 },
                    { 219, 3, 3, 8 },
                    { 220, 4, 3, 8 },
                    { 221, 5, 3, 8 },
                    { 222, 6, 3, 8 },
                    { 223, 7, 3, 8 },
                    { 224, 8, 3, 8 },
                    { 225, 1, 3, 9 },
                    { 226, 2, 3, 9 },
                    { 227, 3, 3, 9 },
                    { 228, 4, 3, 9 },
                    { 229, 5, 3, 9 },
                    { 230, 6, 3, 9 },
                    { 231, 7, 3, 9 },
                    { 232, 8, 3, 9 },
                    { 233, 1, 3, 10 },
                    { 234, 2, 3, 10 },
                    { 235, 3, 3, 10 },
                    { 236, 4, 3, 10 },
                    { 237, 5, 3, 10 },
                    { 238, 6, 3, 10 },
                    { 239, 7, 3, 10 },
                    { 240, 8, 3, 10 }
                });

            migrationBuilder.InsertData(
                table: "ShowTimes",
                columns: new[] { "Id", "EndTime", "MovieId", "RoomId", "StartTime" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 2, 21, 18, 26, 12, 841, DateTimeKind.Utc).AddTicks(2976), 1, 1, new DateTime(2025, 2, 21, 16, 26, 12, 841, DateTimeKind.Utc).AddTicks(2971) },
                    { 2, new DateTime(2025, 2, 21, 19, 26, 12, 841, DateTimeKind.Utc).AddTicks(2979), 2, 2, new DateTime(2025, 2, 21, 17, 26, 12, 841, DateTimeKind.Utc).AddTicks(2978) },
                    { 3, new DateTime(2025, 2, 21, 20, 26, 12, 841, DateTimeKind.Utc).AddTicks(2980), 3, 3, new DateTime(2025, 2, 21, 18, 26, 12, 841, DateTimeKind.Utc).AddTicks(2980) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_SeatId",
                table: "Bookings",
                column: "SeatId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ShowTimeId",
                table: "Bookings",
                column: "ShowTimeId");

            migrationBuilder.CreateIndex(
                name: "IX_Seats_RoomId",
                table: "Seats",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_MovieId",
                table: "ShowTimes",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_ShowTimes_RoomId",
                table: "ShowTimes",
                column: "RoomId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookings");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "ShowTimes");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}

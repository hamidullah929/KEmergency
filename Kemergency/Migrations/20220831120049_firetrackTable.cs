using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kemergency.Migrations
{
    public partial class firetrackTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FireTracks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrackNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    phoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverNumber = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireTracks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FireTrackBookings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MyuserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    FireTrackId = table.Column<int>(type: "int", nullable: true),
                    BookingTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsbookingConfirmed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FireTrackBookings", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FireTrackBookings_Customers_MyuserId",
                        column: x => x.MyuserId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_FireTrackBookings_FireTracks_FireTrackId",
                        column: x => x.FireTrackId,
                        principalTable: "FireTracks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FireTrackBookings_FireTrackId",
                table: "FireTrackBookings",
                column: "FireTrackId");

            migrationBuilder.CreateIndex(
                name: "IX_FireTrackBookings_MyuserId",
                table: "FireTrackBookings",
                column: "MyuserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FireTrackBookings");

            migrationBuilder.DropTable(
                name: "FireTracks");
        }
    }
}

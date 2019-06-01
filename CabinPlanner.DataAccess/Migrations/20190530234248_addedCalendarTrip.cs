using Microsoft.EntityFrameworkCore.Migrations;

namespace CabinPlanner.DataAccess.Migrations
{
    public partial class addedCalendarTrip : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedTrip_Calendar_CalendarId",
                table: "PlannedTrip");

            migrationBuilder.DropIndex(
                name: "IX_PlannedTrip_CalendarId",
                table: "PlannedTrip");

            migrationBuilder.DropColumn(
                name: "CalendarId",
                table: "PlannedTrip");

            migrationBuilder.CreateTable(
                name: "CalendarTrip",
                columns: table => new
                {
                    CalendarId = table.Column<int>(nullable: false),
                    PlannedTripId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CalendarTrip", x => new { x.CalendarId, x.PlannedTripId });
                    table.ForeignKey(
                        name: "FK_CalendarTrip_Calendar_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendar",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CalendarTrip_PlannedTrip_PlannedTripId",
                        column: x => x.PlannedTripId,
                        principalTable: "PlannedTrip",
                        principalColumn: "PlannedTripId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CalendarTrip_PlannedTripId",
                table: "CalendarTrip",
                column: "PlannedTripId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CalendarTrip");

            migrationBuilder.AddColumn<int>(
                name: "CalendarId",
                table: "PlannedTrip",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlannedTrip_CalendarId",
                table: "PlannedTrip",
                column: "CalendarId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedTrip_Calendar_CalendarId",
                table: "PlannedTrip",
                column: "CalendarId",
                principalTable: "Calendar",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CabinPlanner.DataAccess.Migrations
{
    public partial class plannedTripUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedTrip_Person_PersonId",
                table: "PlannedTrip");

            migrationBuilder.DropIndex(
                name: "IX_PlannedTrip_PersonId",
                table: "PlannedTrip");

            migrationBuilder.DropColumn(
                name: "PersonId",
                table: "PlannedTrip");

            migrationBuilder.AddColumn<int>(
                name: "PlannerPersonId",
                table: "PlannedTrip",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PlannedTrip_PlannerPersonId",
                table: "PlannedTrip",
                column: "PlannerPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedTrip_Person_PlannerPersonId",
                table: "PlannedTrip",
                column: "PlannerPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedTrip_Person_PlannerPersonId",
                table: "PlannedTrip");

            migrationBuilder.DropIndex(
                name: "IX_PlannedTrip_PlannerPersonId",
                table: "PlannedTrip");

            migrationBuilder.DropColumn(
                name: "PlannerPersonId",
                table: "PlannedTrip");

            migrationBuilder.AddColumn<int>(
                name: "PersonId",
                table: "PlannedTrip",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PlannedTrip_PersonId",
                table: "PlannedTrip",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedTrip_Person_PersonId",
                table: "PlannedTrip",
                column: "PersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

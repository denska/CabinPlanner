using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CabinPlanner.DataAccess.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Calendars",
                columns: table => new
                {
                    CalendarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendars", x => x.CalendarId);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    FamilyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FamiliyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.FamilyId);
                });

            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    IsMan = table.Column<bool>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CalendarId = table.Column<int>(nullable: true),
                    FamilyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_People_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "FamilyId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cabins",
                columns: table => new
                {
                    CabinId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CabinName = table.Column<string>(nullable: true),
                    CabinOwnerPersonId = table.Column<int>(nullable: true),
                    CalendarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.CabinId);
                    table.ForeignKey(
                        name: "FK_Cabins_People_CabinOwnerPersonId",
                        column: x => x.CabinOwnerPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cabins_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedTrips",
                columns: table => new
                {
                    PlannedTripId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PlannerPersonId = table.Column<int>(nullable: true),
                    Comment = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    CalendarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedTrips", x => x.PlannedTripId);
                    table.ForeignKey(
                        name: "FK_PlannedTrips_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedTrips_People_PlannerPersonId",
                        column: x => x.PlannerPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CabinsUsers",
                columns: table => new
                {
                    CabinsUsersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CabinId = table.Column<int>(nullable: true),
                    PersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinsUsers", x => x.CabinsUsersId);
                    table.ForeignKey(
                        name: "FK_CabinsUsers_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "CabinId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CabinsUsers_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabins_CabinOwnerPersonId",
                table: "Cabins",
                column: "CabinOwnerPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Cabins_CalendarId",
                table: "Cabins",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinsUsers_CabinId",
                table: "CabinsUsers",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinsUsers_PersonId",
                table: "CabinsUsers",
                column: "PersonId");

            migrationBuilder.CreateIndex(
                name: "IX_People_CalendarId",
                table: "People",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_People_FamilyId",
                table: "People",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedTrips_CalendarId",
                table: "PlannedTrips",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedTrips_PlannerPersonId",
                table: "PlannedTrips",
                column: "PlannerPersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinsUsers");

            migrationBuilder.DropTable(
                name: "PlannedTrips");

            migrationBuilder.DropTable(
                name: "Cabins");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}

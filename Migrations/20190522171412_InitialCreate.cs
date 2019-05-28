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
                name: "Calendar",
                columns: table => new
                {
                    CalendarId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calendar", x => x.CalendarId);
                });

            migrationBuilder.CreateTable(
                name: "Family",
                columns: table => new
                {
                    FamilyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FamiliyName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Family", x => x.FamilyId);
                });

            migrationBuilder.CreateTable(
                name: "Person",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    IsMan = table.Column<bool>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    CalendarId = table.Column<int>(nullable: true),
                    FamilyId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Person", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_Person_Calendar_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendar",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Person_Family_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Family",
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
                        name: "FK_Cabins_Person_CabinOwnerPersonId",
                        column: x => x.CabinOwnerPersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cabins_Calendar_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendar",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PlannedTrip",
                columns: table => new
                {
                    PlannedTripId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PersonId = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    FromDate = table.Column<DateTime>(nullable: false),
                    ToDate = table.Column<DateTime>(nullable: false),
                    CalendarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PlannedTrip", x => x.PlannedTripId);
                    table.ForeignKey(
                        name: "FK_PlannedTrip_Calendar_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendar",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PlannedTrip_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CabinUser",
                columns: table => new
                {
                    PersonId = table.Column<int>(nullable: false),
                    CabinId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinUser", x => new { x.PersonId, x.CabinId });
                    table.ForeignKey(
                        name: "FK_CabinUser_Cabins_CabinId",
                        column: x => x.CabinId,
                        principalTable: "Cabins",
                        principalColumn: "CabinId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CabinUser_Person_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Person",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "IX_CabinUser_CabinId",
                table: "CabinUser",
                column: "CabinId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_CalendarId",
                table: "Person",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Person_FamilyId",
                table: "Person",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedTrip_CalendarId",
                table: "PlannedTrip",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_PlannedTrip_PersonId",
                table: "PlannedTrip",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CabinUser");

            migrationBuilder.DropTable(
                name: "PlannedTrip");

            migrationBuilder.DropTable(
                name: "Cabins");

            migrationBuilder.DropTable(
                name: "Person");

            migrationBuilder.DropTable(
                name: "Calendar");

            migrationBuilder.DropTable(
                name: "Family");
        }
    }
}

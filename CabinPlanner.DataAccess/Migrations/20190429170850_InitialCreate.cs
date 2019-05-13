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
                name: "CabinUsers",
                columns: table => new
                {
                    CabinUsersId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CabinId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinUsers", x => x.CabinUsersId);
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
                    FamilyId = table.Column<int>(nullable: true),
                    CabinUsersId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.PersonId);
                    table.ForeignKey(
                        name: "FK_People_CabinUsers_CabinUsersId",
                        column: x => x.CabinUsersId,
                        principalTable: "CabinUsers",
                        principalColumn: "CabinUsersId",
                        onDelete: ReferentialAction.Restrict);
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
                    OwnerPersonId = table.Column<int>(nullable: true),
                    CalendarId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cabins", x => x.CabinId);
                    table.ForeignKey(
                        name: "FK_Cabins_Calendars_CalendarId",
                        column: x => x.CalendarId,
                        principalTable: "Calendars",
                        principalColumn: "CalendarId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Cabins_People_OwnerPersonId",
                        column: x => x.OwnerPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
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
                name: "Relations",
                columns: table => new
                {
                    RelationId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    TheirRelation = table.Column<string>(nullable: true),
                    PersonAPersonId = table.Column<int>(nullable: true),
                    PersonBPersonId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relations", x => x.RelationId);
                    table.ForeignKey(
                        name: "FK_Relations_People_PersonAPersonId",
                        column: x => x.PersonAPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Relations_People_PersonBPersonId",
                        column: x => x.PersonBPersonId,
                        principalTable: "People",
                        principalColumn: "PersonId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cabins_CalendarId",
                table: "Cabins",
                column: "CalendarId");

            migrationBuilder.CreateIndex(
                name: "IX_Cabins_OwnerPersonId",
                table: "Cabins",
                column: "OwnerPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_CabinUsers_CabinId",
                table: "CabinUsers",
                column: "CabinId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_People_CabinUsersId",
                table: "People",
                column: "CabinUsersId");

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

            migrationBuilder.CreateIndex(
                name: "IX_Relations_PersonAPersonId",
                table: "Relations",
                column: "PersonAPersonId");

            migrationBuilder.CreateIndex(
                name: "IX_Relations_PersonBPersonId",
                table: "Relations",
                column: "PersonBPersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_CabinUsers_Cabins_CabinId",
                table: "CabinUsers",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "CabinId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabins_Calendars_CalendarId",
                table: "Cabins");

            migrationBuilder.DropForeignKey(
                name: "FK_People_Calendars_CalendarId",
                table: "People");

            migrationBuilder.DropForeignKey(
                name: "FK_Cabins_People_OwnerPersonId",
                table: "Cabins");

            migrationBuilder.DropTable(
                name: "PlannedTrips");

            migrationBuilder.DropTable(
                name: "Relations");

            migrationBuilder.DropTable(
                name: "Calendars");

            migrationBuilder.DropTable(
                name: "People");

            migrationBuilder.DropTable(
                name: "CabinUsers");

            migrationBuilder.DropTable(
                name: "Families");

            migrationBuilder.DropTable(
                name: "Cabins");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace CabinPlanner.DataAccess.Migrations
{
    public partial class update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabins_Person_CabinOwnerPersonId",
                table: "Cabins");

            migrationBuilder.DropForeignKey(
                name: "FK_Cabins_Calendar_CalendarId",
                table: "Cabins");

            migrationBuilder.DropForeignKey(
                name: "FK_CabinUser_Cabins_CabinId",
                table: "CabinUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabins",
                table: "Cabins");

            migrationBuilder.RenameTable(
                name: "Cabins",
                newName: "Cabin");

            migrationBuilder.RenameIndex(
                name: "IX_Cabins_CalendarId",
                table: "Cabin",
                newName: "IX_Cabin_CalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_Cabins_CabinOwnerPersonId",
                table: "Cabin",
                newName: "IX_Cabin_CabinOwnerPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabin",
                table: "Cabin",
                column: "CabinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabin_Person_CabinOwnerPersonId",
                table: "Cabin",
                column: "CabinOwnerPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cabin_Calendar_CalendarId",
                table: "Cabin",
                column: "CalendarId",
                principalTable: "Calendar",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CabinUser_Cabin_CabinId",
                table: "CabinUser",
                column: "CabinId",
                principalTable: "Cabin",
                principalColumn: "CabinId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cabin_Person_CabinOwnerPersonId",
                table: "Cabin");

            migrationBuilder.DropForeignKey(
                name: "FK_Cabin_Calendar_CalendarId",
                table: "Cabin");

            migrationBuilder.DropForeignKey(
                name: "FK_CabinUser_Cabin_CabinId",
                table: "CabinUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cabin",
                table: "Cabin");

            migrationBuilder.RenameTable(
                name: "Cabin",
                newName: "Cabins");

            migrationBuilder.RenameIndex(
                name: "IX_Cabin_CalendarId",
                table: "Cabins",
                newName: "IX_Cabins_CalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_Cabin_CabinOwnerPersonId",
                table: "Cabins",
                newName: "IX_Cabins_CabinOwnerPersonId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cabins",
                table: "Cabins",
                column: "CabinId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cabins_Person_CabinOwnerPersonId",
                table: "Cabins",
                column: "CabinOwnerPersonId",
                principalTable: "Person",
                principalColumn: "PersonId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Cabins_Calendar_CalendarId",
                table: "Cabins",
                column: "CalendarId",
                principalTable: "Calendar",
                principalColumn: "CalendarId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CabinUser_Cabins_CabinId",
                table: "CabinUser",
                column: "CabinId",
                principalTable: "Cabins",
                principalColumn: "CabinId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

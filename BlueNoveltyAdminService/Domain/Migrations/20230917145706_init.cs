using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Domain.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HouseholdCleaningPricings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    room = table.Column<string>(type: "text", nullable: false),
                    roomServiceDescription = table.Column<string>(type: "text", nullable: false),
                    price = table.Column<decimal>(type: "numeric", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdCleaningPricings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdDetails",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    numberOfBedrooms = table.Column<int>(type: "integer", nullable: false),
                    numberOfBathrooms = table.Column<int>(type: "integer", nullable: false),
                    numberOfAdditionalRooms = table.Column<int>(type: "integer", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    UserType = table.Column<int>(type: "integer", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    PrefferedLanguage = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CleaningRequests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    dateOfRequest = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    totalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    user_Id = table.Column<Guid>(type: "uuid", nullable: true),
                    userId = table.Column<Guid>(type: "uuid", nullable: true),
                    householdDetail_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_CleaningRequests_HouseholdDetails_householdDetail_Id",
                        column: x => x.householdDetail_Id,
                        principalTable: "HouseholdDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CleaningRequests_Users_userId",
                        column: x => x.userId,
                        principalTable: "Users",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleaningRequests_householdDetail_Id",
                table: "CleaningRequests",
                column: "householdDetail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningRequests_userId",
                table: "CleaningRequests",
                column: "userId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleaningRequests");

            migrationBuilder.DropTable(
                name: "HouseholdCleaningPricings");

            migrationBuilder.DropTable(
                name: "HouseholdDetails");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

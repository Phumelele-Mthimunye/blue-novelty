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
                name: "Customers",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "HouseholdCleaningPricings",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    cleaningTask = table.Column<string>(type: "text", nullable: false),
                    cleaningTaskDescription = table.Column<string>(type: "text", nullable: true),
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
                    laundry = table.Column<bool>(type: "boolean", nullable: false),
                    fridge = table.Column<bool>(type: "boolean", nullable: false),
                    garage = table.Column<bool>(type: "boolean", nullable: false),
                    cabinets = table.Column<bool>(type: "boolean", nullable: false),
                    windows = table.Column<bool>(type: "boolean", nullable: false),
                    walls = table.Column<bool>(type: "boolean", nullable: false),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HouseholdDetails", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "ServiceProviders",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    Username = table.Column<string>(type: "text", nullable: false),
                    FirstName = table.Column<string>(type: "text", nullable: false),
                    LastName = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    PhoneNumber = table.Column<string>(type: "text", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "bytea", nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "bytea", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: false),
                    PrefferedLanguage = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceProviders", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Services",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceName = table.Column<string>(type: "text", nullable: true),
                    serviceDescription = table.Column<string>(type: "text", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Services", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "CleaningRequests",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    dateOfRequest = table.Column<DateOnly>(type: "date", nullable: false),
                    status = table.Column<int>(type: "integer", nullable: false),
                    totalPrice = table.Column<decimal>(type: "numeric", nullable: false),
                    customer_Id = table.Column<Guid>(type: "uuid", nullable: true),
                    customerId = table.Column<Guid>(type: "uuid", nullable: true),
                    householdDetail_Id = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceProvider_Id = table.Column<Guid>(type: "uuid", nullable: true),
                    active = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CleaningRequests", x => x.id);
                    table.ForeignKey(
                        name: "FK_CleaningRequests_Customers_customerId",
                        column: x => x.customerId,
                        principalTable: "Customers",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_CleaningRequests_HouseholdDetails_householdDetail_Id",
                        column: x => x.householdDetail_Id,
                        principalTable: "HouseholdDetails",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CleaningRequests_ServiceProviders_serviceProvider_Id",
                        column: x => x.serviceProvider_Id,
                        principalTable: "ServiceProviders",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CleaningRequests_customerId",
                table: "CleaningRequests",
                column: "customerId");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningRequests_householdDetail_Id",
                table: "CleaningRequests",
                column: "householdDetail_Id");

            migrationBuilder.CreateIndex(
                name: "IX_CleaningRequests_serviceProvider_Id",
                table: "CleaningRequests",
                column: "serviceProvider_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CleaningRequests");

            migrationBuilder.DropTable(
                name: "HouseholdCleaningPricings");

            migrationBuilder.DropTable(
                name: "Services");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "HouseholdDetails");

            migrationBuilder.DropTable(
                name: "ServiceProviders");
        }
    }
}

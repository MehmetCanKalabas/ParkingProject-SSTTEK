using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Parking.Model.Migrations
{
    public partial class initialcreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CarParks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsOpen = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarParks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TyreChangedVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TyreChangedVehicle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarParkId = table.Column<int>(type: "int", nullable: true),
                    CarParkType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Plate = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ModelYear = table.Column<int>(type: "int", maxLength: 4, nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    EntryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckOutTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StayTime = table.Column<double>(type: "float", nullable: false),
                    HasParked = table.Column<bool>(type: "bit", nullable: false),
                    IsPaid = table.Column<bool>(type: "bit", nullable: false),
                    ServiceFee = table.Column<double>(type: "float", nullable: false),
                    MotorPowerInKW = table.Column<double>(type: "float", nullable: false),
                    WashedVehicleId = table.Column<int>(type: "int", nullable: true),
                    Autopilot = table.Column<bool>(type: "bit", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TyreChangedVehicleId = table.Column<int>(type: "int", nullable: true),
                    LuggageVolume = table.Column<double>(type: "float", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vehicles_CarParks_CarParkId",
                        column: x => x.CarParkId,
                        principalTable: "CarParks",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Vehicles_TyreChangedVehicle_TyreChangedVehicleId",
                        column: x => x.TyreChangedVehicleId,
                        principalTable: "TyreChangedVehicle",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "WashedVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WashedVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WashedVehicle_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "CarParks",
                columns: new[] { "Id", "IsOpen" },
                values: new object[] { 1, true });

            migrationBuilder.CreateIndex(
                name: "IX_TyreChangedVehicle_VehicleId",
                table: "TyreChangedVehicle",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_CarParkId",
                table: "Vehicles",
                column: "CarParkId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TyreChangedVehicleId",
                table: "Vehicles",
                column: "TyreChangedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_WashedVehicleId",
                table: "Vehicles",
                column: "WashedVehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_WashedVehicle_VehicleId",
                table: "WashedVehicle",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_TyreChangedVehicle_Vehicles_VehicleId",
                table: "TyreChangedVehicle",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_WashedVehicle_WashedVehicleId",
                table: "Vehicles",
                column: "WashedVehicleId",
                principalTable: "WashedVehicle",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TyreChangedVehicle_Vehicles_VehicleId",
                table: "TyreChangedVehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_WashedVehicle_Vehicles_VehicleId",
                table: "WashedVehicle");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "CarParks");

            migrationBuilder.DropTable(
                name: "TyreChangedVehicle");

            migrationBuilder.DropTable(
                name: "WashedVehicle");
        }
    }
}

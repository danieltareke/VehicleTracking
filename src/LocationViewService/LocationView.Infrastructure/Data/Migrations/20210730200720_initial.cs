using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace LocationView.Infrastructure.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "vts");

            migrationBuilder.CreateTable(
                name: "device_info",
                schema: "vts",
                columns: table => new
                {
                    device_id = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    plate_no = table.Column<DateTime>(type: "timestamp without time zone", maxLength: 30, nullable: false),
                    registration_time = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device_info", x => x.device_id);
                });

            migrationBuilder.CreateTable(
                name: "device_location",
                schema: "vts",
                columns: table => new
                {
                    DeviceLocationId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    time_stamp = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    latitude = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    longitude = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    DeviceId = table.Column<string>(type: "character varying(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device_location", x => x.DeviceLocationId);
                    table.ForeignKey(
                        name: "FK_device_location_device_info_DeviceId",
                        column: x => x.DeviceId,
                        principalSchema: "vts",
                        principalTable: "device_info",
                        principalColumn: "device_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_device_location_DeviceId",
                schema: "vts",
                table: "device_location",
                column: "DeviceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "device_location",
                schema: "vts");

            migrationBuilder.DropTable(
                name: "device_info",
                schema: "vts");
        }
    }
}

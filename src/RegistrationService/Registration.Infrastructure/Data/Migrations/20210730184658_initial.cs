using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Registration.Infrastructure.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "vts");

            migrationBuilder.CreateTable(
                name: "device_registration",
                schema: "vts",
                columns: table => new
                {
                    device_id = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    RegistrationTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_device_registration", x => x.device_id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "device_registration",
                schema: "vts");
        }
    }
}

﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafe.Migrations
{
    public partial class addSandswitchesandSpicys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sandswitches",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sandswitches", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Spicys",
                columns: table => new
                {
                    SpicyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Spicys", x => x.SpicyId);
                });

            migrationBuilder.InsertData(
                table: "Spicys",
                columns: new[] { "SpicyId", "Name" },
                values: new object[] { 1, "hot" });

            migrationBuilder.InsertData(
                table: "Spicys",
                columns: new[] { "SpicyId", "Name" },
                values: new object[] { 2, "normal" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sandswitches");

            migrationBuilder.DropTable(
                name: "Spicys");
        }
    }
}

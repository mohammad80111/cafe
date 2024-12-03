using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cafe.Migrations
{
    public partial class addspicyinsandwitch : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SpicyId",
                table: "Sandswitches",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sandswitches_SpicyId",
                table: "Sandswitches",
                column: "SpicyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sandswitches_Spicys_SpicyId",
                table: "Sandswitches",
                column: "SpicyId",
                principalTable: "Spicys",
                principalColumn: "SpicyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sandswitches_Spicys_SpicyId",
                table: "Sandswitches");

            migrationBuilder.DropIndex(
                name: "IX_Sandswitches_SpicyId",
                table: "Sandswitches");

            migrationBuilder.DropColumn(
                name: "SpicyId",
                table: "Sandswitches");
        }
    }
}

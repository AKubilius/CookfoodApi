using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cookfood.Migrations
{
    /// <inheritdoc />
    public partial class smallupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Recepies",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Recepies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Recepies_UserId1",
                table: "Recepies",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepies_AspNetUsers_UserId1",
                table: "Recepies",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepies_AspNetUsers_UserId1",
                table: "Recepies");

            migrationBuilder.DropIndex(
                name: "IX_Recepies_UserId1",
                table: "Recepies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Recepies");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Recepies");
        }
    }
}

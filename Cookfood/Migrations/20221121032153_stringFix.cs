using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cookfood.Migrations
{
    /// <inheritdoc />
    public partial class stringFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepies_AspNetUsers_UserId1",
                table: "Recepies");

            migrationBuilder.DropForeignKey(
                name: "FK_RecepySets_AspNetUsers_UserId1",
                table: "RecepySets");

            migrationBuilder.DropIndex(
                name: "IX_RecepySets_UserId1",
                table: "RecepySets");

            migrationBuilder.DropIndex(
                name: "IX_Recepies_UserId1",
                table: "Recepies");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "RecepySets");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Recepies");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RecepySets",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Recepies",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_RecepySets_UserId",
                table: "RecepySets",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Recepies_UserId",
                table: "Recepies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recepies_AspNetUsers_UserId",
                table: "Recepies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RecepySets_AspNetUsers_UserId",
                table: "RecepySets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepies_AspNetUsers_UserId",
                table: "Recepies");

            migrationBuilder.DropForeignKey(
                name: "FK_RecepySets_AspNetUsers_UserId",
                table: "RecepySets");

            migrationBuilder.DropIndex(
                name: "IX_RecepySets_UserId",
                table: "RecepySets");

            migrationBuilder.DropIndex(
                name: "IX_Recepies_UserId",
                table: "Recepies");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "RecepySets",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "RecepySets",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Recepies",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "UserId1",
                table: "Recepies",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RecepySets_UserId1",
                table: "RecepySets",
                column: "UserId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_RecepySets_AspNetUsers_UserId1",
                table: "RecepySets",
                column: "UserId1",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}

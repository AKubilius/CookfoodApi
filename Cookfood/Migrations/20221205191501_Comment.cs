using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Cookfood.Migrations
{
    /// <inheritdoc />
    public partial class Comment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recepies_AspNetUsers_UserId",
                table: "Recepies");

            migrationBuilder.DropForeignKey(
                name: "FK_RecepySets_AspNetUsers_UserId",
                table: "RecepySets");

            migrationBuilder.DropTable(
                name: "recepyIngredients");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RecepySets",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Recepies",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "RecepyId",
                table: "Ingredients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Recepies_AspNetUsers_UserId",
                table: "Recepies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RecepySets_AspNetUsers_UserId",
                table: "RecepySets",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
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

            migrationBuilder.DropColumn(
                name: "RecepyId",
                table: "Ingredients");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "RecepySets",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Recepies",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "recepyIngredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IngredientId = table.Column<int>(type: "int", nullable: false),
                    RecepyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recepyIngredients", x => x.Id);
                });

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
    }
}

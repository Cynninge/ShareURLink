using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareURLink.Migrations
{
    public partial class Likes4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Links");

            migrationBuilder.AlterColumn<int>(
                name: "LinkId",
                table: "Likes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Likes_LinkId",
                table: "Likes",
                column: "LinkId");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Links_LinkId",
                table: "Likes",
                column: "LinkId",
                principalTable: "Links",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Links_LinkId",
                table: "Likes");

            migrationBuilder.DropIndex(
                name: "IX_Likes_LinkId",
                table: "Likes");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "LinkId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

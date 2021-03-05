using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareURLink.Migrations
{
    public partial class Likes3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "linkId",
                table: "Likes",
                newName: "LinkId");

            migrationBuilder.AlterColumn<int>(
                name: "LinkId",
                table: "Likes",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LinkId",
                table: "Likes",
                newName: "linkId");

            migrationBuilder.AlterColumn<string>(
                name: "linkId",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}

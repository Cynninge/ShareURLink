using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareURLink.Migrations
{
    public partial class Likes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeModel_AspNetUsers_UserModelId",
                table: "LikeModel");

            migrationBuilder.DropIndex(
                name: "IX_LikeModel_UserModelId",
                table: "LikeModel");

            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "LinkId",
                table: "LikeModel");

            migrationBuilder.DropColumn(
                name: "UserModelId",
                table: "LikeModel");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "LikeModel",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateTable(
                name: "LikeModelLinkModel",
                columns: table => new
                {
                    LikesId = table.Column<int>(type: "int", nullable: false),
                    LinksId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeModelLinkModel", x => new { x.LikesId, x.LinksId });
                    table.ForeignKey(
                        name: "FK_LikeModelLinkModel_LikeModel_LikesId",
                        column: x => x.LikesId,
                        principalTable: "LikeModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeModelLinkModel_Links_LinksId",
                        column: x => x.LinksId,
                        principalTable: "Links",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LikeModel_UserId",
                table: "LikeModel",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LikeModelLinkModel_LinksId",
                table: "LikeModelLinkModel",
                column: "LinksId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeModel_AspNetUsers_UserId",
                table: "LikeModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeModel_AspNetUsers_UserId",
                table: "LikeModel");

            migrationBuilder.DropTable(
                name: "LikeModelLinkModel");

            migrationBuilder.DropIndex(
                name: "IX_LikeModel_UserId",
                table: "LikeModel");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "LikeModel",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LinkId",
                table: "LikeModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "UserModelId",
                table: "LikeModel",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LikeModel_UserModelId",
                table: "LikeModel",
                column: "UserModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeModel_AspNetUsers_UserModelId",
                table: "LikeModel",
                column: "UserModelId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

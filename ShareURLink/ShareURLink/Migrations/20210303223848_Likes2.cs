using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareURLink.Migrations
{
    public partial class Likes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LikeModelLinkModel");

            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Links",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "linkId",
                table: "Likes",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Links");

            migrationBuilder.DropColumn(
                name: "linkId",
                table: "Likes");

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
                        name: "FK_LikeModelLinkModel_Likes_LikesId",
                        column: x => x.LikesId,
                        principalTable: "Likes",
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
                name: "IX_LikeModelLinkModel_LinksId",
                table: "LikeModelLinkModel",
                column: "LinksId");
        }
    }
}

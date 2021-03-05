using Microsoft.EntityFrameworkCore.Migrations;

namespace ShareURLink.Migrations
{
    public partial class Likes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeModel_AspNetUsers_UserId",
                table: "LikeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeModelLinkModel_LikeModel_LikesId",
                table: "LikeModelLinkModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeModel",
                table: "LikeModel");

            migrationBuilder.RenameTable(
                name: "LikeModel",
                newName: "Likes");

            migrationBuilder.RenameIndex(
                name: "IX_LikeModel_UserId",
                table: "Likes",
                newName: "IX_Likes_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeModelLinkModel_Likes_LikesId",
                table: "LikeModelLinkModel",
                column: "LikesId",
                principalTable: "Likes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeModelLinkModel_Likes_LikesId",
                table: "LikeModelLinkModel");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_AspNetUsers_UserId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "LikeModel");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId",
                table: "LikeModel",
                newName: "IX_LikeModel_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeModel",
                table: "LikeModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeModel_AspNetUsers_UserId",
                table: "LikeModel",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikeModelLinkModel_LikeModel_LikesId",
                table: "LikeModelLinkModel",
                column: "LikesId",
                principalTable: "LikeModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

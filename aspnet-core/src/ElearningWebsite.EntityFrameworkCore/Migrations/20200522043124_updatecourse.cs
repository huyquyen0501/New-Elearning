using Microsoft.EntityFrameworkCore.Migrations;

namespace ElearningWebsite.Migrations
{
    public partial class updatecourse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Courses_CreatorUserId",
                table: "Courses",
                column: "CreatorUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_AbpUsers_CreatorUserId",
                table: "Courses",
                column: "CreatorUserId",
                principalTable: "AbpUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_AbpUsers_CreatorUserId",
                table: "Courses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_CreatorUserId",
                table: "Courses");
        }
    }
}

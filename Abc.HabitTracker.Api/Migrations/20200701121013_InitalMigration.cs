using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.HabitTracker.Api.Migrations
{
    public partial class InitalMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Logs_HabitID",
                table: "Logs",
                column: "HabitID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserID",
                table: "Logs",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Habits_HabitID",
                table: "Logs",
                column: "HabitID",
                principalTable: "Habits",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_User_UserID",
                table: "Logs",
                column: "UserID",
                principalTable: "User",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Habits_HabitID",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_User_UserID",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_HabitID",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_UserID",
                table: "Logs");
        }
    }
}

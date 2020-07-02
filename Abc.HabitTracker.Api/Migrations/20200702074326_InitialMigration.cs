using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.HabitTracker.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Badges_Users_UserID",
                table: "Badges");

            migrationBuilder.DropForeignKey(
                name: "FK_Habits_Users_UserID",
                table: "Habits");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Habits_HabitID",
                table: "Logs");

            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Users_UserID",
                table: "Logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Habits",
                table: "Habits");

            migrationBuilder.DropIndex(
                name: "IX_Habits_UserID",
                table: "Habits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Logs",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_UserID",
                table: "Logs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Badges",
                table: "Badges");

            migrationBuilder.DropIndex(
                name: "IX_Badges_UserID",
                table: "Badges");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "users");

            migrationBuilder.RenameTable(
                name: "Habits",
                newName: "habits");

            migrationBuilder.RenameTable(
                name: "Logs",
                newName: "user_habit");

            migrationBuilder.RenameTable(
                name: "DayOff",
                newName: "habit_day_off");

            migrationBuilder.RenameTable(
                name: "Badges",
                newName: "badge");

            migrationBuilder.RenameIndex(
                name: "IX_Logs_HabitID",
                table: "user_habit",
                newName: "IX_user_habit_HabitID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_users",
                table: "users",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_habits",
                table: "habits",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_habit",
                table: "user_habit",
                column: "LogsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_badge",
                table: "badge",
                column: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_user_habit_habits_HabitID",
                table: "user_habit",
                column: "HabitID",
                principalTable: "habits",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_habit_habits_HabitID",
                table: "user_habit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_users",
                table: "users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_habits",
                table: "habits");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_habit",
                table: "user_habit");

            migrationBuilder.DropPrimaryKey(
                name: "PK_badge",
                table: "badge");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "habits",
                newName: "Habits");

            migrationBuilder.RenameTable(
                name: "user_habit",
                newName: "Logs");

            migrationBuilder.RenameTable(
                name: "habit_day_off",
                newName: "DayOff");

            migrationBuilder.RenameTable(
                name: "badge",
                newName: "Badges");

            migrationBuilder.RenameIndex(
                name: "IX_user_habit_HabitID",
                table: "Logs",
                newName: "IX_Logs_HabitID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Habits",
                table: "Habits",
                column: "ID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Logs",
                table: "Logs",
                column: "LogsID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Badges",
                table: "Badges",
                column: "ID");

            migrationBuilder.CreateIndex(
                name: "IX_Habits_UserID",
                table: "Habits",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserID",
                table: "Logs",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Badges_UserID",
                table: "Badges",
                column: "UserID");

            migrationBuilder.AddForeignKey(
                name: "FK_Badges_Users_UserID",
                table: "Badges",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Habits_Users_UserID",
                table: "Habits",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Habits_HabitID",
                table: "Logs",
                column: "HabitID",
                principalTable: "Habits",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Users_UserID",
                table: "Logs",
                column: "UserID",
                principalTable: "Users",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

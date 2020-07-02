using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Abc.HabitTracker.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.ID);
                });


            migrationBuilder.CreateTable(
                name: "badge",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_badge", x => x.ID);
                    table.ForeignKey(
                        name: "FK_badge_UserID",
                        column: x => x.UserID,
                        principalTable: "user",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade
                    );
                });

            migrationBuilder.CreateTable(
                name: "habit",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    UserID = table.Column<Guid>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_habit", x => x.ID);
                    table.ForeignKey(
                        name: "FK_habit_UserID",
                        column: x => x.UserID,
                        principalTable: "user",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade
                    );
                });

            migrationBuilder.CreateTable(
                name: "habit_dayoff",
                columns: table => new
                {
                    DayName = table.Column<string>(nullable: true),
                    HabitID = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_habit_day_off_HabitID",
                        column: x => x.HabitID,
                        principalTable: "habit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade
                    );
                });

            migrationBuilder.CreateTable(
                name: "user_habit",
                columns: table => new
                {
                    LogsID = table.Column<Guid>(nullable: false),
                    UserID = table.Column<Guid>(nullable: false),
                    HabitID = table.Column<Guid>(nullable: false),
                    DayName = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_habit", x => x.LogsID);
                    table.ForeignKey(
                        name: "FK_user_habit_habit_HabitID",
                        column: x => x.HabitID,
                        principalTable: "habit",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_habit_HabitID",
                table: "user_habit",
                column: "HabitID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "badge");

            migrationBuilder.DropTable(
                name: "habit_dayoff");

            migrationBuilder.DropTable(
                name: "user_habit");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "habit");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ExerciseTracker.Data.Migrations
{
    public partial class AddConnectionbetweenUserAndWorkoutEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workout_records_users_user_id",
                table: "workout_records");

            migrationBuilder.DropIndex(
                name: "IX_workout_records_user_id",
                table: "workout_records");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "workout_records");

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "workouts",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_workouts_user_id",
                table: "workouts",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_workouts_users_user_id",
                table: "workouts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workouts_users_user_id",
                table: "workouts");

            migrationBuilder.DropIndex(
                name: "IX_workouts_user_id",
                table: "workouts");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "workouts");

            migrationBuilder.AddColumn<long>(
                name: "user_id",
                table: "workout_records",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_workout_records_user_id",
                table: "workout_records",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "FK_workout_records_users_user_id",
                table: "workout_records",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

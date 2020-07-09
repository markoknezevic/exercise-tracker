using Microsoft.EntityFrameworkCore.Migrations;

namespace ExerciseTracker.Data.Migrations
{
    public partial class AddStatusIdInExerciseWorkoutEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "status_id",
                table: "exercise_workouts",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_exercise_workouts_status_id",
                table: "exercise_workouts",
                column: "status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_exercise_workouts_statuses_status_id",
                table: "exercise_workouts",
                column: "status_id",
                principalTable: "statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_exercise_workouts_statuses_status_id",
                table: "exercise_workouts");

            migrationBuilder.DropIndex(
                name: "IX_exercise_workouts_status_id",
                table: "exercise_workouts");

            migrationBuilder.DropColumn(
                name: "status_id",
                table: "exercise_workouts");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ExerciseTracker.Data.Migrations
{
    public partial class AddStatusIdInWorkoutsEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<short>(
                name: "status_id",
                table: "workouts",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.CreateIndex(
                name: "IX_workouts_status_id",
                table: "workouts",
                column: "status_id");

            migrationBuilder.AddForeignKey(
                name: "FK_workouts_statuses_status_id",
                table: "workouts",
                column: "status_id",
                principalTable: "statuses",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_workouts_statuses_status_id",
                table: "workouts");

            migrationBuilder.DropIndex(
                name: "IX_workouts_status_id",
                table: "workouts");

            migrationBuilder.DropColumn(
                name: "status_id",
                table: "workouts");
        }
    }
}

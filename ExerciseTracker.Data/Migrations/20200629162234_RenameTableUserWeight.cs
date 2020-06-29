using Microsoft.EntityFrameworkCore.Migrations;

namespace ExerciseTracker.Data.Migrations
{
    public partial class RenameTableUserWeight : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_weight_users_user_id",
                table: "user_weight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_weight",
                table: "user_weight");

            migrationBuilder.RenameTable(
                name: "user_weight",
                newName: "user_weights");

            migrationBuilder.RenameIndex(
                name: "IX_user_weight_user_id",
                table: "user_weights",
                newName: "IX_user_weights_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_weights",
                table: "user_weights",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_weights_users_user_id",
                table: "user_weights",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_weights_users_user_id",
                table: "user_weights");

            migrationBuilder.DropPrimaryKey(
                name: "PK_user_weights",
                table: "user_weights");

            migrationBuilder.RenameTable(
                name: "user_weights",
                newName: "user_weight");

            migrationBuilder.RenameIndex(
                name: "IX_user_weights_user_id",
                table: "user_weight",
                newName: "IX_user_weight_user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_user_weight",
                table: "user_weight",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_weight_users_user_id",
                table: "user_weight",
                column: "user_id",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

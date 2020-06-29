using System.ComponentModel;
using System.Linq;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExerciseTracker.Data.Migrations
{
    public partial class AddStatusSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql((new Status()
            {
                Id = (int) Statuses.Undefined,
                Name = Statuses.Undefined.GetType().GetField(Statuses.Undefined.ToString())
                    .GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>()
                    .FirstOrDefault()
                    ?.DisplayName

            }).InsertSql);
            
            migrationBuilder.Sql((new Status()
            {
                Id = (int) Statuses.Active,
                Name = Statuses.Active.GetType().GetField(Statuses.Active.ToString())
                    .GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>()
                    .FirstOrDefault()
                    ?.DisplayName

            }).InsertSql);
            
            migrationBuilder.Sql((new Status()
            {
                Id = (short) Statuses.Inactive,
                Name = Statuses.Inactive.GetType().GetField(Statuses.Inactive.ToString())
                    .GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>()
                    .FirstOrDefault()
                    ?.DisplayName

            }).InsertSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql((new Status()
            {
                Id = (short) Statuses.Undefined
            }).DeleteSql);
            
            migrationBuilder.Sql((new Status()
            {
                Id = (short) Statuses.Active
            }).DeleteSql);
            
            migrationBuilder.Sql((new Status()
            {
                Id = (short) Statuses.Inactive                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
            }).DeleteSql);
        }
    }
}

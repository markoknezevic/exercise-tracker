using System.ComponentModel;
using System.Linq;
using ExerciseTracker.Data.Entities;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExerciseTracker.Data.Migrations
{
    public partial class AddExerciseSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.Squat,
                Name = Exercises.Squat.GetType().GetField(Exercises.Squat.ToString())
                    .GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>()
                    .FirstOrDefault()
                    ?.DisplayName,
                Description = Exercises.Squat.GetType().GetField(Exercises.Squat.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>()
                    .FirstOrDefault()
                    ?.Description
            }).InsertSql);
            
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.ChestPress,
                Name = Exercises.ChestPress.GetType().GetField(Exercises.ChestPress.ToString())
                    .GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>()
                    .FirstOrDefault()
                    ?.DisplayName,
                Description = Exercises.ChestPress.GetType().GetField(Exercises.ChestPress.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>()
                    .FirstOrDefault()
                    ?.Description
            }).InsertSql);
            
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.LegCurl,
                Name = Exercises.LegCurl.GetType().GetField(Exercises.LegCurl.ToString())
                    .GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>()
                    .FirstOrDefault()
                    ?.DisplayName,
                Description = Exercises.LegCurl.GetType().GetField(Exercises.LegCurl.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>()
                    .FirstOrDefault()
                    ?.Description
            }).InsertSql);
            
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.PushUp,
                Name = Exercises.PushUp.GetType().GetField(Exercises.PushUp.ToString())
                    .GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>()
                    .FirstOrDefault()
                    ?.DisplayName,
                Description = Exercises.PushUp.GetType().GetField(Exercises.PushUp.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>()
                    .FirstOrDefault()
                    ?.Description
            }).InsertSql);
            
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.ShoulderPress,
                Name = Exercises.ShoulderPress.GetType().GetField(Exercises.ShoulderPress.ToString())
                    .GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>()
                    .FirstOrDefault()
                    ?.DisplayName,
                Description = Exercises.ShoulderPress.GetType().GetField(Exercises.ShoulderPress.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>()
                    .FirstOrDefault()
                    ?.Description
            }).InsertSql);
            
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.SitUp,
                Name = Exercises.SitUp.GetType().GetField(Exercises.SitUp.ToString())
                    .GetCustomAttributes(typeof(DisplayNameAttribute), false).Cast<DisplayNameAttribute>()
                    .FirstOrDefault()
                    ?.DisplayName,
                Description = Exercises.SitUp.GetType().GetField(Exercises.SitUp.ToString())
                    .GetCustomAttributes(typeof(DescriptionAttribute), false).Cast<DescriptionAttribute>()
                    .FirstOrDefault()
                    ?.Description
            }).InsertSql);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.Squat,
            }).DeleteSql);
            
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.ChestPress,
            }).DeleteSql);
            
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.LegCurl,
            }).DeleteSql);
            
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.LegCurl,
            }).DeleteSql);
            
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.PushUp,
            }).DeleteSql);
            
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.ShoulderPress,
            }).DeleteSql);
            
            migrationBuilder.Sql((new Exercise()
            {
                Id = (long) Exercises.SitUp,
            }).DeleteSql);
        }
    }
}

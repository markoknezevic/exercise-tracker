using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Data.Entities
{
    public enum Exercises : long
    {
        [DisplayName("Push-Up")]
        [Description("By raising and lowering the body using the arms, push-ups exercise the pectoral muscles, triceps, and anterior deltoids, with ancillary benefits to the rest of the deltoids, serratus anterior, coracobrachialis and the midsection as a whole.")]
        PushUp = 1,
        
        [DisplayName("Squat")]
        [Description("A squat is a strength exercise in which the trainee lowers their hips from a standing position and then stands back up.")]
        Squat = 2,
        
        [DisplayName("Sit-Up")]
        [Description("The sit-up is an abdominal endurance training exercise to strengthen, tighten and tone the abdominal muscles.")]
        SitUp = 3,
        
        [DisplayName("Chest Press")]
        [Description("Sit on the glideboard with your knees bent and hold the handles with your hands on each side of your chest, palms facing down and elbows bent.Slide the glideboard up by pushing on the handles straight forward and allow yourself back down after a short pause.Keep your forearms parallel to the floor throughout.")]
        ChestPress = 4,
        
        [DisplayName("Leg Curl")]
        [Description("Lie on your back on the glideboard with your legs extended and attach your ankles to the wing attachment. Slide the glideboard up by curling your legs and allow yourself back down after a short pause. Breathe out while curling your legs and breathe in while returning to starting position.")]
        LegCurl = 5,
        
        [DisplayName("Shoulder Press")]
        [Description("Lie face down on the glideboard, knees bent and grasp the press-up bars with your hands, elbows bent. Slide the glideboard up by extending your arms (pushing yourself up) and allow yourself back down after a short pause. Breathe out while pushing and breathe in while returning to starting position.")]
        ShoulderPress = 6,
        
        
    }
    
    [Table("exercises")]
    public class Exercise : TimestampedEntity<long>
    {
        [Key]
        [Column("id")]
        public override long Id { get; set; }
        
        [Required]
        [MaxLength(255)]
        [Column("name")]
        public string Name { get; set; }
        
        [MaxLength(500)]
        [Column("description")]
        public string Description { get; set; }
        
        public ICollection<ExerciseWorkout> ExerciseWorkouts { get; set; }
    }
}
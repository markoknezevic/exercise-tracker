using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Data.Entities
{
    [Table("user_weights")]
    public class UserWeight : TimestampedEntity<long>
    {
        [Key]
        [Column("id")]
        public override long Id { get; set; }
        
        [Required]
        [Column("value")]
        public double Value { get; set; }
        
        [Required]
        [Column("user_id")]
        public long UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
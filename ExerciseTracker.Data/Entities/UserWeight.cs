using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ExerciseTracker.Data.Entities
{
    [Table("user_weights")]
    public class UserWeight : TimestampedEntity<long>
    {
        [Key]
        [Column("id", Order = 1)]
        public override long Id { get; set; }
        
        [Required]
        [Column("value", Order = 2)]
        public double Value { get; set; }
        
        [Required]
        [Column("user_id", Order = 3)]
        public long UserId { get; set; }
        
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
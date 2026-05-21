using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("userID")]
        public int UserID { get; set; }

        [Column("name")]
        [MaxLength(255)]
        public string Name { get; set; }=string.Empty;

        [Column("phone_number")]
        [MaxLength(20)]
        public string Phone_Number { get; set; }= string.Empty;

        [Column("email")]
        [MaxLength(50)]
        public string Email { get; set; } = string.Empty;

        [Column("password")]
        [MaxLength(50)]
        public string Password { get; set; }=string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set;} = DateTime.Now;

        
    }
}

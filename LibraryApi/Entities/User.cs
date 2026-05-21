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
        public string Name { get; set; }=string.Empty;

        [Column("phone_number")]
        public string Phone_Number { get; set; }= string.Empty;

        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [Column("password")]
        public string Password { get; set; }=string.Empty;

        [Column("created_at")]
        public DateTime CreatedAt { get; set;} = DateTime.Now;

        
    }
}

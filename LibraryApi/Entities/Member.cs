using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities
{
    public class Member
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("userID")]
        public int UserID { get; set; }

        [Column("membership_id")]
        public string Membership_id { get; set; } = string.Empty;

        [Column("address")]
        public string Address { get; set; } = string.Empty;

        [Column("borrow_limit")]
        public int Borrow_Limit { get; set; } 

        [Column("status")]
        public string Status { get; set; } = string.Empty;
    }
}

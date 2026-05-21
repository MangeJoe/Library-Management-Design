using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities
{
    [Table("Member")]
    public class Member :User
    {
        [Column("membership_id")]
        [MaxLength(20)]
        public string Membership_id { get; set; } = string.Empty;

        [Column("address")]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;

        [Column("borrow_limit")]
        public int Borrow_Limit { get; set; } 

        [Column("status")]
        [MaxLength(20)]
        public string Status { get; set; } = string.Empty;
    }
}

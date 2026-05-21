using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities
{
    [Table("Manager")]
    public class Librarian :User
    {
        [Column("hiredDate")]
        public DateTime HiredDate { get; set; }

        [Column("shift")]
        [MaxLength(2100)]
        public string Shift {  get; set; }= string.Empty;
    }
}

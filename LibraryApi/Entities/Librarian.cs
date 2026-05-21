using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities
{
    public class Librarian :User
    {
        [Column("hiredDate")]
        public DateTime HiredDate { get; set; }

        [Column("shift")]
        public string Shift {  get; set; }= string.Empty;
    }
}

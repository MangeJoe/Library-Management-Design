using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities
{
    [Table("Manager")]
    public class Manager:User
    {
        [Column("officeLocatiom")]
        [MaxLength(255)]
        public string OfficeLocation { get; set; }=string.Empty;

    }
}

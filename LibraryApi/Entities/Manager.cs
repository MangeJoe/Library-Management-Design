using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities
{
    public class Manager
    {
        [Column("officeLocatiom")]
        public string OfficeLocation { get; set; }=string.Empty;

    }
}

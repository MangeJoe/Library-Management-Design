using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryApi.Entities
{
    public class GeneralUser
    {
        public int UserID { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone_Number { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime HiredDate { get; set; }
        public string Shift { get; set; } = string.Empty;
        public string OfficeLocation { get; set; } = string.Empty;
        public string Membership_id { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int Borrow_Limit { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}

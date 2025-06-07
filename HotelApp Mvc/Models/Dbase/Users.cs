using System.ComponentModel.DataAnnotations;

namespace HotelApp_Mvc.Models.Dbase
{
    public class Users
    {
        public int UsersID { get; set; }
        public string UserFName { get; set; }

        [Required]
        public string UserLName { get; set; }
        [MaxLength(10)]
        public string UserCode { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string UserNumber { get; set; }

        [DataType(DataType.Password)]
        [Required]
        public string password { get; set; }

        [DataType(DataType.Password)]
        [Compare(nameof(password))]
        public string repassword { get; set; }

        public ICollection<Reserve> Reserves { get; set; } = new List<Reserve>(); 
    }
}

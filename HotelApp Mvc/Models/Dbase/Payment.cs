using System.ComponentModel.DataAnnotations;

namespace HotelApp_Mvc.Models.Dbase
{
    public class Payment
    {
        [Key]
        public int PaymentID { get; set; }
        public bool PayStatus { get; set; }
        public string PayCode { get; set; }
        public DateTime PayDate { get; set; }

        public int PayPrice { get; set; }

        public int reserveId { get; set; } 
        public Reserve reserve { get; set; } 

    }
}

using System.ComponentModel.DataAnnotations;

namespace HotelApp_Mvc.Models.Dbase
{
    public class Reserve
    {
        [Key]
        public int ReserveID { get; set; } 
         /*long*/
        public int ReservePrice { get; set; }
        public int ReserveCap { get; set; }
        public DateTime checkInDate { get; set; }
        public DateTime checkOutDate { get; set; } 

        public ICollection<RoomDetail> RoomDetail { get; set; } = new List<RoomDetail>();

        /*public Rooms Rooms { get; set; } */
        public int RoomID { get; set; }
        public int UserId { get; set; }
        public Users Users { get; set; } 

        public Payment Payments { get; set; }
    }
}

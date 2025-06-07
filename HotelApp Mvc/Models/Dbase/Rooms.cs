using System.ComponentModel.DataAnnotations;

namespace HotelApp_Mvc.Models.Dbase
{
    public class Rooms
    {
        [Key]
        public int RoomsID { get; set; }
        public string RoomType { get; set; }
        public int RoomCapacity { get; set;}

        public long RoomPrice { get; set; }
        public bool RoomAvail { get; set; }

        public ICollection<RoomDetail> RoomDetails { get; set; } = new List<RoomDetail>(); 

        /*public DateTime reserveDate { get; set; }*/
        /*public ICollection<Reserve> reserves { get; set; } = new List<Reserve>();*/
    }
}

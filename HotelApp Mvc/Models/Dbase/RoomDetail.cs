using MessagePack;

namespace HotelApp_Mvc.Models.Dbase
{
    public class RoomDetail
    {
        /*[Key] */
        public int RoomDetailID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int ReserveID { get; set; }
        public Reserve Reserve { get; set; } 

        public int RoomID { get; set; }
        public Rooms Rooms { get; set; } 
        /*public ICollection<Reserve> reserves { get; set; } = new List<Reserve>();*/


    }
}

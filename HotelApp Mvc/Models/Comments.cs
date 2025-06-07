namespace HotelApp_Mvc.Models
{
    public class Comments
    {
        public int CommentsId { get; set; }
        public string NameU { get; set; } 
        public string UserEmail { get; set; }
        public string UserComment { get; set; }
        public string StarComment { get; set; }

        public bool acceptCom { get; set; } = false;

    }
}

using System.ComponentModel.DataAnnotations;

namespace HotelApp_Mvc.Models.Dbase
{
    public class Discount
    {
        [Key]
        public int DiscountID { get; set; }
        [Required]
        [MaxLength(10)]
        public string DiscountCode { get; set; }
        public DateTime FinishDate { get; set; }
        public int DisPercent { get; set; }
        public bool DiscountEnabled { get; set; }
    }
}

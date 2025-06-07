using Microsoft.AspNetCore.Mvc;

namespace HotelApp_Mvc.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult UserSpecification()
        {
            return View();
        }

        public IActionResult ReservationList()
        {
            return View();
        }

        public IActionResult PaymentList()
        {
            return View();
        }
    }
}

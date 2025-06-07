using Microsoft.AspNetCore.Mvc;

namespace HotelApp_Mvc.Controllers
{
    public class PanelAdminController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
        public IActionResult index()
        {
            return View();
        }
    }
}

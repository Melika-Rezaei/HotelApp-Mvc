using HotelApp_Mvc.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using HotelApp_Mvc.Models.Dbase;
using HotelApp_Mvc.Data;

namespace HotelApp_Mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

/*        private readonly HotelApp_MvcContext _context;

        public HomeController(HotelApp_MvcContext context)
        {
            _context = context;
        }*/


        public IActionResult Index()
        {
            return View();
        }
/*        public static List<Rooms> rooms = new List<Rooms>();
        static HomeController()
        {
            rooms.Add(new Rooms()
            {
                RoomId = 1, Zarfiyat = 3, Price = 1000000, RoomType = "سوییت"
            });
        };*/
        public IActionResult Rooms()
        {
            return View(); 
        }
        public IActionResult RoomDetail()
        {
            return View(); 
        }
        public IActionResult ABoutUs()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
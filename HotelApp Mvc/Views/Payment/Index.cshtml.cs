using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelApp_Mvc.Data;
using HotelApp_Mvc.Models.Dbase;

namespace HotelApp_Mvc.Views.Payment
{
    public class IndexModel : PageModel
    {
        private readonly HotelApp_Mvc.Data.HotelApp_MvcContext _context;

        public IndexModel(HotelApp_Mvc.Data.HotelApp_MvcContext context)
        {
            _context = context;
        }

        public IList<HotelApp_Mvc.Models.Dbase.Payment> Payment { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Payment != null)
            {
                Payment = await _context.Payment
                .Include(p => p.reserve).ToListAsync();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelApp_Mvc.Data;
using HotelApp_Mvc.Models.Dbase;

namespace HotelApp_Mvc.Views.Discounts1
{
    public class IndexModel : PageModel
    {
        private readonly HotelApp_MvcContext _context;

        public IndexModel(HotelApp_MvcContext context)
        {
            _context = context;
        }

        public IList<Discount> Discount { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Discount != null)
            {
                Discount = await _context.Discount.ToListAsync();
            }
        }
    }
}

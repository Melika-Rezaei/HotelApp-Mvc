using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HotelApp_Mvc.Data;
using HotelApp_Mvc.Models.Dbase;

namespace HotelApp_Mvc.Controllers
{
    public class DeleteModel : PageModel
    {
        private readonly HotelApp_Mvc.Data.HotelApp_MvcContext _context;

        public DeleteModel(HotelApp_Mvc.Data.HotelApp_MvcContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Discount Discount { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Discount == null)
            {
                return NotFound();
            }

            var discount = await _context.Discount.FirstOrDefaultAsync(m => m.DiscountID == id);

            if (discount == null)
            {
                return NotFound();
            }
            else 
            {
                Discount = discount;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Discount == null)
            {
                return NotFound();
            }
            var discount = await _context.Discount.FindAsync(id);

            if (discount != null)
            {
                Discount = discount;
                _context.Discount.Remove(Discount);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

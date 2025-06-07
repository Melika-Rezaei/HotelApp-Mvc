using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HotelApp_Mvc.Data;
using HotelApp_Mvc.Models.Dbase;

namespace HotelApp_Mvc.Controllers
{
    public class CreateModel : PageModel
    {
        private readonly HotelApp_Mvc.Data.HotelApp_MvcContext _context;

        public CreateModel(HotelApp_Mvc.Data.HotelApp_MvcContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Discount Discount { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Discount == null || Discount == null)
            {
                return Page();
            }

            _context.Discount.Add(Discount);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

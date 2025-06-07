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
    public class DetailsModel : PageModel
    {
        private readonly HotelApp_Mvc.Data.HotelApp_MvcContext _context;

        public DetailsModel(HotelApp_Mvc.Data.HotelApp_MvcContext context)
        {
            _context = context;
        }

      public HotelApp_Mvc.Models.Dbase.Payment Payment { get; set; } = default!; 

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Payment == null)
            {
                return NotFound();
            }

            var payment = await _context.Payment.FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }
            else 
            {
                Payment = payment;
            }
            return Page();
        }
    }
}

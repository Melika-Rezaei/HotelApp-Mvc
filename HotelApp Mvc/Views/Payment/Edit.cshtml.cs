using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelApp_Mvc.Data;
using HotelApp_Mvc.Models.Dbase;

namespace HotelApp_Mvc.Views.Payment
{
    public class EditModel : PageModel
    {
        private readonly HotelApp_Mvc.Data.HotelApp_MvcContext _context;

        public EditModel(HotelApp_Mvc.Data.HotelApp_MvcContext context)
        {
            _context = context;
        }

        [BindProperty]
        public HotelApp_Mvc.Models.Dbase.Payment Payment { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Payment == null)
            {
                return NotFound();
            }

            var payment =  await _context.Payment.FirstOrDefaultAsync(m => m.PaymentID == id);
            if (payment == null)
            {
                return NotFound();
            }
            Payment = payment;
           ViewData["reserveId"] = new SelectList(_context.Set<Reserve>(), "ReserveID", "ReserveID");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(Payment.PaymentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PaymentExists(int id)
        {
          return (_context.Payment?.Any(e => e.PaymentID == id)).GetValueOrDefault();
        }
    }
}

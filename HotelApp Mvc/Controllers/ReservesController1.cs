using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelApp_Mvc.Data;
using HotelApp_Mvc.Models.Dbase;

namespace HotelApp_Mvc.Controllers
{
    public class ReservesController1 : Controller
    {
        private readonly HotelApp_MvcContext _context;

        public ReservesController1(HotelApp_MvcContext context)
        {
            _context = context;
        }

        // GET: Reserves
        public async Task<IActionResult> Index()
        {
              return _context.Reserve != null ? 
                          View(await _context.Reserve.ToListAsync()) :
                          Problem("Entity set 'HotelApp_MvcContext.Reserve'  is null.");
        }

        // GET: Reserves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Reserve == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserve
                .FirstOrDefaultAsync(m => m.ReserveID == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }
        //reserve a room 
        public async Task<IActionResult> Payment(int id)
        {
            var product = await _context.Reserve.FindAsync(id); ;
            /*_context.rooms.Find(id);*/
            Payment payment1 = new Payment();
            payment1.reserveId = id; 
            payment1.PayDate = DateTime.Now;
            payment1.PayStatus = false;
            payment1.PayCode = "Default";
            int sumPrice = Convert.ToInt32(product.ReservePrice);
            payment1.PayPrice = sumPrice;
            /*product.RoomPrice;*/

            _context.Payment.Add(payment1); 
            /*_context.reserve.Add(reserve);*/


            var payment = await new ZarinpalSandbox.Payment(sumPrice).PaymentRequest("رزرو اتاق" ,
            Url.Action(nameof(Index)));

            if (payment.Status == 100)
            {
                return Redirect(payment.Link);
            }
            else
            {
                //return errorPage;
                return RedirectToAction("ErrorPage", "Home");
            }
        }
        /*        public async Task<IActionResult> Payment(int id)
                {
                    var product = await _context.Reserve.FindAsync(id); ;
                    _context.rooms.Find(id);
                    Payment payment = new Payment();
                    payment.PayDate = DateTime.Now;
                    payment.PayStatus = false;
                    payment.PayCode = product.RoomPrice;
                    product.RoomPrice;
                    int sumPrice = Convert.ToInt32(product.RoomPrice);

                    _context.reserve.Add(reserve);


                    var payment = await new ZarinpalSandbox.Payment(100).PaymentRequest("رزرو " + product.roomName,
                    Url.Action(nameof(Index)));

                    if (payment.Status == 100)
                    {
                        return Redirect(payment.Link);
                    }
                    else
                    {
                        //return errorPage;
                        return RedirectToAction("ErrorPage", "Home");
                    }
                }*/


        // GET: Reserves/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Reserves/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReserveID,ReservePrice,ReserveCap,checkInDate,RoomID,checkOutDate,UserId")] Reserve reserve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserve);
        }
        //Reserve a room 
        public IActionResult RoomReserve()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RoomReserve([Bind("ReserveID,ReservePrice,ReserveCap,checkInDate,RoomID,checkOutDate")] Reserve reserve)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reserve);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(reserve);
        }


        // GET: Reserves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Reserve == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserve.FindAsync(id);
            if (reserve == null)
            {
                return NotFound();
            }
            return View(reserve);
        }

        // POST: Reserves/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReserveID,ReservePrice,ReserveCap,checkInDate,checkOutDate")] Reserve reserve)
        {
            if (id != reserve.ReserveID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reserve);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReserveExists(reserve.ReserveID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(reserve);
        }

        // GET: Reserves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Reserve == null)
            {
                return NotFound();
            }

            var reserve = await _context.Reserve
                .FirstOrDefaultAsync(m => m.ReserveID == id);
            if (reserve == null)
            {
                return NotFound();
            }

            return View(reserve);
        }

        // POST: Reserves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Reserve == null)
            {
                return Problem("Entity set 'HotelApp_MvcContext.Reserve'  is null.");
            }
            var reserve = await _context.Reserve.FindAsync(id);
            if (reserve != null)
            {
                _context.Reserve.Remove(reserve);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReserveExists(int id)
        {
          return (_context.Reserve?.Any(e => e.ReserveID == id)).GetValueOrDefault();
        }
    }
}

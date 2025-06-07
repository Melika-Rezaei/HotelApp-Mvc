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
    public class RoomsController : Controller
    {
        private readonly HotelApp_MvcContext _context;

        public RoomsController(HotelApp_MvcContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
              return _context.Rooms != null ? 
                          View(await _context.Rooms.ToListAsync()) :
                          Problem("Entity set 'HotelApp_MvcContext.Rooms'  is null.");
        }
        //List of rooms 
        public async Task<IActionResult> RoomsList()
        {
            return _context.Rooms != null ?
                        View(await _context.Rooms.ToListAsync()) :
                        Problem("Entity set 'HotelApp_MvcContext.Rooms'  is null.");
        }


        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var rooms = await _context.Rooms
                .FirstOrDefaultAsync(m => m.RoomsID == id);
            if (rooms == null)
            {
                return NotFound();
            }

            return View(rooms);
        }
        // GET: Rooms/Details/5
        //For user
        public async Task<IActionResult> RoomDetail(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var rooms = await _context.Rooms
                .FirstOrDefaultAsync(m => m.RoomsID == id);
            if (rooms == null)
            {
                return NotFound();
            }

            return View(rooms);
        }


        /*       [HttpPost]
               public IActionResult RoomDetail(string discountCode)
               {
                   // دریافت کد تخفیف و بررسی اعتبار آن
                   if (discountCode == "MYDISCOUNT")
                   {
                       // محاسبه مبلغ نهایی با درصد تخفیف
                       decimal totalAmount = 100; // مبلغ کل
                       decimal discountPercentage = 10; // درصد تخفیف
                       decimal discountAmount = totalAmount * discountPercentage / 100;
                       decimal finalAmount = totalAmount - discountAmount;

                       // ارسال مبلغ نهایی به view
                       ViewData["FinalAmount"] = finalAmount;
                   }
                   else
                   {
                       // کد تخفیف نامعتبر است
                       ViewData["FinalAmount"] = null;
                   }

                   return View();
               }*/
        public async Task<IActionResult> Payment(int id, int roomPrice)
        {
            /*TempData["RoomPrice"] = roomPrice;*/
            var product = await _context.Rooms.FindAsync(id); ;
            /*_context.rooms.Find(id);*/
            
            Payment payment1 = new Payment();
            payment1.reserveId = id;
            payment1.PayDate = DateTime.Now;
            payment1.PayStatus = false;
            payment1.PayCode = "Default";
            /*Rooms room1 = new Rooms();*/
            /*payment1.PayPrice = product.RoomPrice;*/
            payment1.PayPrice = 1400000;
            /* payment1.PayPrice = roomPrice; */

            /*payment1.PayPrice = Convert.ToInt32(product.RoomPrice);*/
            /* int sumPrice = Convert.ToInt32(product.RoomPrice);*/
            /*        payment1.PayPrice = sumPrice;*/
            /*product.RoomPrice;*/
            _context.Add(payment1);
            /*await _context.SaveChangesAsync();*/
            /*_context.Payment.Add(payment1);*/
            /*_context.reserve.Add(reserve);*/


            var payment = await new ZarinpalSandbox.Payment(payment1.PayPrice).PaymentRequest("رزرو اتاق" ,
            Url.Action(nameof(Index)));

            if (payment.Status == 100)
            {
                return Redirect(payment.Link);
                /*payment1.PayStatus=true; */
                /*return RedirectToAction("SuccessPay","Payments");*/
            }
            else
            {
                //return errorPage;
                /*return RedirectToAction("ErrorPage", "Home");*/
                return RedirectToAction("faildPay","Payments");
            }
        }
        /*        public async Task<IActionResult> RoomReserve(int id)
                {
                    var reserve = await _context.Rooms.FindAsync(id); ;
                    *//*_context.rooms.Find(id);*//*
                    Reserve reserve1 = new Reserve();
                    reserve1.RoomID = id;
                    reserve1.checkInDate = ;
                    reserve1.checkOutDate = ;
                    reserve1.ReserveCap = ;
                    reserve1.ReservePrice = ; 
        *//*            reserve1.PayStatus = false;
                    reserve1.PayCode = "Default";
                    int sumPrice = Convert.ToInt32(product.ReservePrice);
                    reserve1.PayPrice = sumPrice;*/
        /*product.RoomPrice;*//*

        _context.Reserve.Add(reserve1);
        *//*_context.reserve.Add(reserve);*//*
        return View(); 

    }*/

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomsID,RoomType,RoomCapacity,RoomPrice,RoomAvail")] Rooms rooms)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rooms);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rooms);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var rooms = await _context.Rooms.FindAsync(id);
            if (rooms == null)
            {
                return NotFound();
            }
            return View(rooms);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomsID,RoomType,RoomCapacity,RoomPrice,RoomAvail")] Rooms rooms)
        {
            if (id != rooms.RoomsID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rooms);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomsExists(rooms.RoomsID))
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
            return View(rooms);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rooms == null)
            {
                return NotFound();
            }

            var rooms = await _context.Rooms
                .FirstOrDefaultAsync(m => m.RoomsID == id);
            if (rooms == null)
            {
                return NotFound();
            }

            return View(rooms);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rooms == null)
            {
                return Problem("Entity set 'HotelApp_MvcContext.Rooms'  is null.");
            }
            var rooms = await _context.Rooms.FindAsync(id);
            if (rooms != null)
            {
                _context.Rooms.Remove(rooms);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomsExists(int id)
        {
          return (_context.Rooms?.Any(e => e.RoomsID == id)).GetValueOrDefault();
        }
    }
}

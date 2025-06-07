using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HotelApp_Mvc.Data;
using HotelApp_Mvc.Models;

namespace HotelApp_Mvc.Controllers
{
    public class CommentsController : Controller
    {
        private readonly HotelApp_MvcContext _context;

        public CommentsController(HotelApp_MvcContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            return _context.Comments != null ?
                        View(await _context.Comments.ToListAsync()) :
                        Problem("Entity set 'HotelApp_MvcContext.Comments'  is null.");
        }
        public async Task<IActionResult> ShowComments()
        {
            return _context.Comments != null ?
                        View(await _context.Comments.ToListAsync()) :
                        Problem("Entity set 'HotelApp_MvcContext.Comments'  is null.");
        }
        public async Task<IActionResult> UsersComments()
        {
            return _context.Comments != null ?
                        View(await _context.Comments.ToListAsync()) :
                        Problem("Entity set 'HotelApp_MvcContext.Comments'  is null.");
        }
        /*        public IActionResult UsersComments()
                {
                    return View();
                }*/
        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments
                .FirstOrDefaultAsync(m => m.CommentsId == id);
            if (comments == null)
            {
                return NotFound();
            }

            return View(comments);
        }

        // GET: Comments/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentsId,NameU,UserEmail,UserComment,StarComment,acceptCom")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(comments);
        }


        // add Comments 

        public IActionResult addComments()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addComments([Bind("CommentsId,NameU,UserEmail,UserComment,StarComment")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(ShowComments));
            }
            /*return View(comments);*/
           /* return View("ShowComments");*/
            return RedirectToAction("ShowComments");
        }


        // GET: Comments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }
            return View(comments);
        }

        // POST: Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentsId,NameU,UserEmail,UserComment,StarComment,acceptCom")] Comments comments)
        {
            if (id != comments.CommentsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentsExists(comments.CommentsId))
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
            return View(comments);
        }

        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments
                .FirstOrDefaultAsync(m => m.CommentsId == id);
            if (comments == null)
            {
                return NotFound();
            }

            return View(comments);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Comments == null)
            {
                return Problem("Entity set 'HotelApp_MvcContext.Comments'  is null.");
            }
            var comments = await _context.Comments.FindAsync(id);
            if (comments != null)
            {
                _context.Comments.Remove(comments);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentsExists(int id)
        {
          return (_context.Comments?.Any(e => e.CommentsId == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Elktab.Data;
using Elktab.Data.context;
using Elktab.Logic.Books.Helper;
using Elktab.Logic.Categories.Helper;
using Elktab.Models;

namespace Elktab.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBook _Book;
        private readonly ICategory _category;

        public BooksController(IBook book , ICategory category)
        {
            _Book = book;
            _category = category; 
        }


        public async Task<IActionResult> Index()
        {
            var Books = _Book.getAllAsync();
            return View(await Books);
        }


        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _Book.Get(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }


        public async Task<IActionResult> Create()
        {
           
            BookDTO book = new BookDTO() { categories = await _category.getAllAsync() }; 
            return View(book);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookDTO book)
        {
            if (ModelState.IsValid)
            {
                if (_Book.Create(book) != null)
                    return RedirectToAction(nameof(Index));
                
            }
            ViewData["Categories"] = new SelectList(await _category.getAllAsync(), "ID", "Name" , book.CategoryID);

            return View(book);
        }

        //    // GET: Books/Edit/5
        //    public async Task<IActionResult> Edit(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var book = await _context.Books.FindAsync(id);
        //        if (book == null)
        //        {
        //            return NotFound();
        //        }
        //        ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name", book.CategoryID);
        //        return View(book);
        //    }

        //    // POST: Books/Edit/5
        //    // To protect from overposting attacks, enable the specific properties you want to bind to.
        //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //    [HttpPost]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> Edit(int id, [Bind("ID,Rate,Level,CategoryID,UserID")] Book book)
        //    {
        //        if (id != book.ID)
        //        {
        //            return NotFound();
        //        }

        //        if (ModelState.IsValid)
        //        {
        //            try
        //            {
        //                _context.Update(book);
        //                await _context.SaveChangesAsync();
        //            }
        //            catch (DbUpdateConcurrencyException)
        //            {
        //                if (!BookExists(book.ID))
        //                {
        //                    return NotFound();
        //                }
        //                else
        //                {
        //                    throw;
        //                }
        //            }
        //            return RedirectToAction(nameof(Index));
        //        }
        //        ViewData["CategoryID"] = new SelectList(_context.Categories, "ID", "Name", book.CategoryID);
        //        return View(book);
        //    }

        //    // GET: Books/Delete/5
        //    public async Task<IActionResult> Delete(int? id)
        //    {
        //        if (id == null)
        //        {
        //            return NotFound();
        //        }

        //        var book = await _context.Books
        //            .Include(b => b.Category)
        //            .FirstOrDefaultAsync(m => m.ID == id);
        //        if (book == null)
        //        {
        //            return NotFound();
        //        }

        //        return View(book);
        //    }

        //    // POST: Books/Delete/5
        //    [HttpPost, ActionName("Delete")]
        //    [ValidateAntiForgeryToken]
        //    public async Task<IActionResult> DeleteConfirmed(int id)
        //    {
        //        var book = await _context.Books.FindAsync(id);
        //        _context.Books.Remove(book);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }

        //    private bool BookExists(int id)
        //    {
        //        return _context.Books.Any(e => e.ID == id);
        //    }
    }
}

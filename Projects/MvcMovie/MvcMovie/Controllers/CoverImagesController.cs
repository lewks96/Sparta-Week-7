using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{
    public class CoverImagesController : Controller
    {
        private readonly MvcMovieContext _context;

        public CoverImagesController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: CoverImages
        public async Task<IActionResult> Index()
        {
              return View(await _context.CoverImage.ToListAsync());
        }

        // GET: CoverImages/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CoverImage == null)
            {
                return NotFound();
            }

            var coverImage = await _context.CoverImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coverImage == null)
            {
                return NotFound();
            }

            return View(coverImage);
        }

        // GET: CoverImages/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CoverImages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Format,ImageData")] CoverImage coverImage)
        {
            if (ModelState.IsValid)
            {
                _context.Add(coverImage);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(coverImage);
        }

        // GET: CoverImages/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CoverImage == null)
            {
                return NotFound();
            }

            var coverImage = await _context.CoverImage.FindAsync(id);
            if (coverImage == null)
            {
                return NotFound();
            }
            return View(coverImage);
        }

        // POST: CoverImages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Format,ImageData")] CoverImage coverImage)
        {
            if (id != coverImage.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(coverImage);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CoverImageExists(coverImage.Id))
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
            return View(coverImage);
        }

        // GET: CoverImages/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CoverImage == null)
            {
                return NotFound();
            }

            var coverImage = await _context.CoverImage
                .FirstOrDefaultAsync(m => m.Id == id);
            if (coverImage == null)
            {
                return NotFound();
            }

            return View(coverImage);
        }

        // POST: CoverImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CoverImage == null)
            {
                return Problem("Entity set 'MvcMovieContext.CoverImage'  is null.");
            }
            var coverImage = await _context.CoverImage.FindAsync(id);
            if (coverImage != null)
            {
                _context.CoverImage.Remove(coverImage);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CoverImageExists(int id)
        {
          return _context.CoverImage.Any(e => e.Id == id);
        }
    }
}

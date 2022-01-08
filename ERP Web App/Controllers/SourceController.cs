using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ERP_Web_App.Models;

namespace ERP_Web_App.Controllers
{
    public class SourceController : Controller
    {
        private readonly AppDbContext _context;

        public SourceController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Source
        public async Task<IActionResult> Index()
        {
            var appDbContext = await _context.SourceMaster.Include(s => s.Model)
                                .Include(s => s.Brand)
                                .ToListAsync();
            return View(appDbContext);
        }

        // GET: Source/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var source = await _context.SourceMaster
                .Include(s => s.Brand)
                .FirstOrDefaultAsync(m => m.SourceId == id);
            if (source == null)
            {
                return NotFound();
            }

            return View(source);
        }

        // GET: Source/Create
        public IActionResult Create()
        {
            ViewData["ModelId"] = new SelectList(_context.ModelMaster, "ModelId", "ModelName");
            ViewData["BrandId"] = new SelectList(_context.BrandMaster, "BrandId", "BrandName");
            return View();
        }

        // POST: Source/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SourceId,Date,SourceName,LotNo,RAM,ROM,Color,IMEI,IMEI2,BrandId,ModelId")] Source source)
        {
            source.CreatedBy = "Tester";
            if (ModelState.IsValid)
            {
                _context.Add(source);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.BrandMaster, "BrandId", "BrandName", source.BrandId);
            ViewData["ModelId"] = new SelectList(_context.ModelMaster, "ModelId", "ModelName", source.ModelId);
            return View(source);
        }

        // GET: Source/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var source = await _context.SourceMaster.FindAsync(id);
            if (source == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.BrandMaster, "BrandId", "BrandName", source.BrandId);
            ViewData["ModelId"] = new SelectList(_context.ModelMaster, "ModelId", "ModelName", source.ModelId);
            return View(source);
        }

        // POST: Source/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("SourceId,Date,SourceName,LotNo,RAM,ROM,Color,IMEI,IMEI2,CreatedBy,CreatedOn,BrandId,ModelId,")] Source source)
        {
            source.UpdatedBy = "Tester";
            source.UpdatedOn = DateTime.Now;
            if (id != source.SourceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(source);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SourceExists(source.SourceId))
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
            ViewData["BrandId"] = new SelectList(_context.BrandMaster, "BrandId", "BrandName", source.BrandId);
            ViewData["ModelId"] = new SelectList(_context.ModelMaster, "ModelId", "ModelName", source.ModelId);
            return View(source);
        }

        // GET: Source/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var source = await _context.SourceMaster
                .Include(s => s.Brand)
                .FirstOrDefaultAsync(m => m.SourceId == id);
            if (source == null)
            {
                return NotFound();
            }

            return View(source);
        }

        // POST: Source/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var source = await _context.SourceMaster.FindAsync(id);
            _context.SourceMaster.Remove(source);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SourceExists(long id)
        {
            return _context.SourceMaster.Any(e => e.SourceId == id);
        }
    }
}

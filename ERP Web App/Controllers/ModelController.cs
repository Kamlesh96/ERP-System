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
    public class ModelController : Controller
    {
        private readonly AppDbContext _context;

        public ModelController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Model
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.ModelMaster.Include(m => m.Brand);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Model/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.ModelMaster
                .Include(m => m.Brand)
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // GET: Model/Create
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.BrandMaster, "BrandId", "BrandName");
            return View();
        }

        // POST: Model/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ModelId,ModelName,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,BrandId")] Model model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.BrandMaster, "BrandId", "BrandName", model.BrandId);
            return View(model);
        }

        // GET: Model/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.ModelMaster.FindAsync(id);
            if (model == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.BrandMaster, "BrandId", "BrandName", model.BrandId);
            return View(model);
        }

        // POST: Model/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ModelId,ModelName,CreatedBy,CreatedOn,UpdatedBy,UpdatedOn,BrandId")] Model model)
        {
            if (id != model.ModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ModelExists(model.ModelId))
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
            ViewData["BrandId"] = new SelectList(_context.BrandMaster, "BrandId", "BrandName", model.BrandId);
            return View(model);
        }

        // GET: Model/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var model = await _context.ModelMaster
                .Include(m => m.Brand)
                .FirstOrDefaultAsync(m => m.ModelId == id);
            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }

        // POST: Model/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var model = await _context.ModelMaster.FindAsync(id);
            _context.ModelMaster.Remove(model);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ModelExists(long id)
        {
            return _context.ModelMaster.Any(e => e.ModelId == id);
        }
    }
}

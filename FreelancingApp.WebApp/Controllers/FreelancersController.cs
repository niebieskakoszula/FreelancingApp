using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FreelancingApp.WebApp.Data;
using FreelancingApp.WebApp.Models;

namespace FreelancingApp.WebApp.Controllers
{
    public class FreelancersController : Controller
    {
        private readonly AppDbContext _context;

        public FreelancersController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Freelancers
        public async Task<IActionResult> Index()
        {
              return _context.Freelancers != null ? 
                          View(await _context.Freelancers.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.Freelancer'  is null.");
        }

        // GET: Freelancers/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Freelancers == null)
            {
                return NotFound();
            }

            var freelancer = await _context.Freelancers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (freelancer == null)
            {
                return NotFound();
            }

            return View(freelancer);
        }

        // GET: Freelancers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Freelancers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FreelancerId,PhotoUrl,Description")] Freelancer freelancer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(freelancer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(freelancer);
        }

        // GET: Freelancers/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Freelancers == null)
            {
                return NotFound();
            }

            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer == null)
            {
                return NotFound();
            }
            return View(freelancer);
        }

        // POST: Freelancers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,FreelancerId,PhotoUrl,Description")] Freelancer freelancer)
        {
            if (id != freelancer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(freelancer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FreelancerExists(freelancer.Id))
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
            return View(freelancer);
        }

        // GET: Freelancers/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Freelancers == null)
            {
                return NotFound();
            }

            var freelancer = await _context.Freelancers
                .FirstOrDefaultAsync(m => m.Id == id);
            if (freelancer == null)
            {
                return NotFound();
            }

            return View(freelancer);
        }

        // POST: Freelancers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Freelancers == null)
            {
                return Problem("Entity set 'AppDbContext.Freelancer'  is null.");
            }
            var freelancer = await _context.Freelancers.FindAsync(id);
            if (freelancer != null)
            {
                _context.Freelancers.Remove(freelancer);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FreelancerExists(string id)
        {
          return (_context.Freelancers?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DS_ArthurGOAREGUER.Models;

namespace DS_ArthurGOAREGUER.Controllers
{
    public class JeuxController : Controller
    {
        private readonly MVC_DS_ArthurGOAREGUERContext _context;

        public JeuxController(MVC_DS_ArthurGOAREGUERContext context)
        {
            _context = context;
        }

        // GET: Jeux
        public async Task<IActionResult> Index()
        {
            return View(await _context.Jeux.ToListAsync());
        }

        // GET: Jeux/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jeux = await _context.Jeux
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jeux == null)
            {
                return NotFound();
            }

            return View(jeux);
        }

        // GET: Jeux/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Jeux/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nom")] Jeux jeux)
        {
            if (ModelState.IsValid)
            {
                _context.Add(jeux);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(jeux);
        }

        // GET: Jeux/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jeux = await _context.Jeux.FindAsync(id);
            if (jeux == null)
            {
                return NotFound();
            }
            return View(jeux);
        }

        // POST: Jeux/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nom")] Jeux jeux)
        {
            if (id != jeux.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(jeux);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!JeuxExists(jeux.Id))
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
            return View(jeux);
        }

        // GET: Jeux/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var jeux = await _context.Jeux
                .FirstOrDefaultAsync(m => m.Id == id);
            if (jeux == null)
            {
                return NotFound();
            }

            return View(jeux);
        }

        // POST: Jeux/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var jeux = await _context.Jeux.FindAsync(id);
            _context.Jeux.Remove(jeux);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool JeuxExists(int id)
        {
            return _context.Jeux.Any(e => e.Id == id);
        }
    }
}

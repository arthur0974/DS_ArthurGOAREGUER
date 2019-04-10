using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DS_ArthurGOAREGUER.Models;

namespace DS_ArthurGOAREGUER.Views
{
    public class ChampionnatsController : Controller
    {
        private readonly MVC_DS_ArthurGOAREGUERContext _context;

        public ChampionnatsController(MVC_DS_ArthurGOAREGUERContext context)
        {
            _context = context;
        }

        // GET: Championnats
        public async Task<IActionResult> Index()
        {
            var mVC_DS_ArthurGOAREGUERContext = _context.Championnat.Include(c => c.Jeux).Include(c => c.Tournoi);
            return View(await mVC_DS_ArthurGOAREGUERContext.ToListAsync());
        }

        // GET: Championnats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championnat = await _context.Championnat
                .Include(c => c.Jeux)
                .Include(c => c.Tournoi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (championnat == null)
            {
                return NotFound();
            }

            return View(championnat);
        }

        // GET: Championnats/Create
        public IActionResult Create()
        {
            ViewData["JeuxId"] = new SelectList(_context.Set<Jeux>(), "Id", "Nom");
            ViewData["TournoiId"] = new SelectList(_context.Set<Tournoi>(), "Id", "Description");
            return View();
        }

        // POST: Championnats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TournoiId,JeuxId,Nom")] Championnat championnat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(championnat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["JeuxId"] = new SelectList(_context.Set<Jeux>(), "Id", "Nom", championnat.JeuxId);
            ViewData["TournoiId"] = new SelectList(_context.Set<Tournoi>(), "Id", "Description", championnat.TournoiId);
            return View(championnat);
        }

        // GET: Championnats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championnat = await _context.Championnat.FindAsync(id);
            if (championnat == null)
            {
                return NotFound();
            }
            ViewData["JeuxId"] = new SelectList(_context.Set<Jeux>(), "Id", "Nom", championnat.JeuxId);
            ViewData["TournoiId"] = new SelectList(_context.Set<Tournoi>(), "Id", "Description", championnat.TournoiId);
            return View(championnat);
        }

        // POST: Championnats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TournoiId,JeuxId,Nom")] Championnat championnat)
        {
            if (id != championnat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(championnat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChampionnatExists(championnat.Id))
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
            ViewData["JeuxId"] = new SelectList(_context.Set<Jeux>(), "Id", "Nom", championnat.JeuxId);
            ViewData["TournoiId"] = new SelectList(_context.Set<Tournoi>(), "Id", "Description", championnat.TournoiId);
            return View(championnat);
        }

        // GET: Championnats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var championnat = await _context.Championnat
                .Include(c => c.Jeux)
                .Include(c => c.Tournoi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (championnat == null)
            {
                return NotFound();
            }

            return View(championnat);
        }

        // POST: Championnats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var championnat = await _context.Championnat.FindAsync(id);
            _context.Championnat.Remove(championnat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChampionnatExists(int id)
        {
            return _context.Championnat.Any(e => e.Id == id);
        }
    }
}

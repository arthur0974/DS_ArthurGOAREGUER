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
    public class ResultatsController : Controller
    {
        private readonly MVC_DS_ArthurGOAREGUERContext _context;

        public ResultatsController(MVC_DS_ArthurGOAREGUERContext context)
        {
            _context = context;
        }

        // GET: Resultats
        public async Task<IActionResult> Index()
        {
            var mVC_DS_ArthurGOAREGUERContext = _context.Resultat.Include(r => r.Championnat).Include(r => r.Personne1).Include(r => r.Personne2);
            return View(await mVC_DS_ArthurGOAREGUERContext.ToListAsync());
        }

        // GET: Resultats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultat = await _context.Resultat
                .Include(r => r.Championnat)
                .Include(r => r.Personne1)
                .Include(r => r.Personne2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultat == null)
            {
                return NotFound();
            }

            return View(resultat);
        }

        // GET: Resultats/Create
        public IActionResult Create()
        {
            ViewData["ChampionnatId"] = new SelectList(_context.Championnat, "Id", "Nom");
            ViewData["Personne1Id"] = new SelectList(_context.Personne, "Id", "DateNaissance");
            ViewData["Personne2Id"] = new SelectList(_context.Personne, "Id", "DateNaissance");
            return View();
        }

        // POST: Resultats/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChampionnatId,Personne1Id,Personne2Id,Score1,Score2,DateDebut")] Resultat resultat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(resultat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChampionnatId"] = new SelectList(_context.Championnat, "Id", "Nom", resultat.ChampionnatId);
            ViewData["Personne1Id"] = new SelectList(_context.Personne, "Id", "DateNaissance", resultat.Personne1Id);
            ViewData["Personne2Id"] = new SelectList(_context.Personne, "Id", "DateNaissance", resultat.Personne2Id);
            return View(resultat);
        }

        // GET: Resultats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultat = await _context.Resultat.FindAsync(id);
            if (resultat == null)
            {
                return NotFound();
            }
            ViewData["ChampionnatId"] = new SelectList(_context.Championnat, "Id", "Nom", resultat.ChampionnatId);
            ViewData["Personne1Id"] = new SelectList(_context.Personne, "Id", "DateNaissance", resultat.Personne1Id);
            ViewData["Personne2Id"] = new SelectList(_context.Personne, "Id", "DateNaissance", resultat.Personne2Id);
            return View(resultat);
        }

        // POST: Resultats/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChampionnatId,Personne1Id,Personne2Id,Score1,Score2,DateDebut")] Resultat resultat)
        {
            if (id != resultat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(resultat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ResultatExists(resultat.Id))
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
            ViewData["ChampionnatId"] = new SelectList(_context.Championnat, "Id", "Nom", resultat.ChampionnatId);
            ViewData["Personne1Id"] = new SelectList(_context.Personne, "Id", "DateNaissance", resultat.Personne1Id);
            ViewData["Personne2Id"] = new SelectList(_context.Personne, "Id", "DateNaissance", resultat.Personne2Id);
            return View(resultat);
        }

        // GET: Resultats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var resultat = await _context.Resultat
                .Include(r => r.Championnat)
                .Include(r => r.Personne1)
                .Include(r => r.Personne2)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (resultat == null)
            {
                return NotFound();
            }

            return View(resultat);
        }

        // POST: Resultats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var resultat = await _context.Resultat.FindAsync(id);
            _context.Resultat.Remove(resultat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ResultatExists(int id)
        {
            return _context.Resultat.Any(e => e.Id == id);
        }
    }
}

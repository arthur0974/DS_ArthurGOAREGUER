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
    public class OrganisationsController : Controller
    {
        private readonly MVC_DS_ArthurGOAREGUERContext _context;

        public OrganisationsController(MVC_DS_ArthurGOAREGUERContext context)
        {
            _context = context;
        }

        // GET: Organisations
        public async Task<IActionResult> Index()
        {
            var mVC_DS_ArthurGOAREGUERContext = _context.Organisation.Include(o => o.Personne).Include(o => o.Poste).Include(o => o.Tournoi);
            return View(await mVC_DS_ArthurGOAREGUERContext.ToListAsync());
        }

        // GET: Organisations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _context.Organisation
                .Include(o => o.Personne)
                .Include(o => o.Poste)
                .Include(o => o.Tournoi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organisation == null)
            {
                return NotFound();
            }

            return View(organisation);
        }

        // GET: Organisations/Create
        public IActionResult Create()
        {
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "DateNaissance");
            ViewData["PosteId"] = new SelectList(_context.Set<Poste>(), "Id", "Nom");
            ViewData["TournoiId"] = new SelectList(_context.Set<Tournoi>(), "Id", "Description");
            return View();
        }

        // POST: Organisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TournoiId,PersonneId,PosteId")] Organisation organisation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(organisation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "DateNaissance", organisation.PersonneId);
            ViewData["PosteId"] = new SelectList(_context.Set<Poste>(), "Id", "Nom", organisation.PosteId);
            ViewData["TournoiId"] = new SelectList(_context.Set<Tournoi>(), "Id", "Description", organisation.TournoiId);
            return View(organisation);
        }

        // GET: Organisations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _context.Organisation.FindAsync(id);
            if (organisation == null)
            {
                return NotFound();
            }
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "DateNaissance", organisation.PersonneId);
            ViewData["PosteId"] = new SelectList(_context.Set<Poste>(), "Id", "Nom", organisation.PosteId);
            ViewData["TournoiId"] = new SelectList(_context.Set<Tournoi>(), "Id", "Description", organisation.TournoiId);
            return View(organisation);
        }

        // POST: Organisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TournoiId,PersonneId,PosteId")] Organisation organisation)
        {
            if (id != organisation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organisation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganisationExists(organisation.Id))
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
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "DateNaissance", organisation.PersonneId);
            ViewData["PosteId"] = new SelectList(_context.Set<Poste>(), "Id", "Nom", organisation.PosteId);
            ViewData["TournoiId"] = new SelectList(_context.Set<Tournoi>(), "Id", "Description", organisation.TournoiId);
            return View(organisation);
        }

        // GET: Organisations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organisation = await _context.Organisation
                .Include(o => o.Personne)
                .Include(o => o.Poste)
                .Include(o => o.Tournoi)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (organisation == null)
            {
                return NotFound();
            }

            return View(organisation);
        }

        // POST: Organisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var organisation = await _context.Organisation.FindAsync(id);
            _context.Organisation.Remove(organisation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganisationExists(int id)
        {
            return _context.Organisation.Any(e => e.Id == id);
        }
    }
}

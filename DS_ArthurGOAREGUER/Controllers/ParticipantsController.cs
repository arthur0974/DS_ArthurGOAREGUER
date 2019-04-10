﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DS_ArthurGOAREGUER.Models;

namespace DS_ArthurGOAREGUER.Controllers
{
    public class ParticipantsController : Controller
    {
        private readonly MVC_DS_ArthurGOAREGUERContext _context;

        public ParticipantsController(MVC_DS_ArthurGOAREGUERContext context)
        {
            _context = context;
        }

        // GET: Participants
        public async Task<IActionResult> Index()
        {
            var mVC_DS_ArthurGOAREGUERContext = _context.Participant.Include(p => p.Championnat).Include(p => p.Personne);
            return View(await mVC_DS_ArthurGOAREGUERContext.ToListAsync());
        }

        // GET: Participants/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant
                .Include(p => p.Championnat)
                .Include(p => p.Personne)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // GET: Participants/Create
        public IActionResult Create()
        {
            ViewData["ChampionnatId"] = new SelectList(_context.Championnat, "Id", "Nom");
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "DateNaissance");
            return View();
        }

        // POST: Participants/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ChampionnatId,PersonneId,Equipe")] Participant participant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(participant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChampionnatId"] = new SelectList(_context.Championnat, "Id", "Nom", participant.ChampionnatId);
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "DateNaissance", participant.PersonneId);
            return View(participant);
        }

        // GET: Participants/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant.FindAsync(id);
            if (participant == null)
            {
                return NotFound();
            }
            ViewData["ChampionnatId"] = new SelectList(_context.Championnat, "Id", "Nom", participant.ChampionnatId);
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "DateNaissance", participant.PersonneId);
            return View(participant);
        }

        // POST: Participants/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ChampionnatId,PersonneId,Equipe")] Participant participant)
        {
            if (id != participant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(participant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParticipantExists(participant.Id))
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
            ViewData["ChampionnatId"] = new SelectList(_context.Championnat, "Id", "Nom", participant.ChampionnatId);
            ViewData["PersonneId"] = new SelectList(_context.Set<Personne>(), "Id", "DateNaissance", participant.PersonneId);
            return View(participant);
        }

        // GET: Participants/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var participant = await _context.Participant
                .Include(p => p.Championnat)
                .Include(p => p.Personne)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (participant == null)
            {
                return NotFound();
            }

            return View(participant);
        }

        // POST: Participants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var participant = await _context.Participant.FindAsync(id);
            _context.Participant.Remove(participant);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParticipantExists(int id)
        {
            return _context.Participant.Any(e => e.Id == id);
        }
    }
}

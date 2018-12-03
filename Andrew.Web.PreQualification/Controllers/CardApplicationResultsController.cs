using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Andrew.Web.PreQualification.Data;
using Andrew.Web.PreQualification.Models.PreQualModels.CcModels;

namespace Andrew.Web.PreQualification.Controllers
{
    public class CardApplicationResultsController : Controller
    {
		/*
        private readonly PreQualificationContext _context;

        public CardApplicationResultsController(PreQualificationContext context)
        {
            _context = context;
        }

        // GET: CardApplicationResults
        public async Task<IActionResult> Index()
        {
            var preQualificationContext = _context.CardApplicationResult.Include(c => c.Card).Include(c => c.CardApplication);
            return View(await preQualificationContext.ToListAsync());
        }

        // GET: CardApplicationResults/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardApplicationResult = await _context.CardApplicationResult
                .Include(c => c.Card)
                .Include(c => c.CardApplication)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cardApplicationResult == null)
            {
                return NotFound();
            }

            return View(cardApplicationResult);
        }

        // GET: CardApplicationResults/Create
        public IActionResult Create()
        {
            ViewData["CardID"] = new SelectList(_context.Card, "ID", "ID");
            ViewData["ApplicationID"] = new SelectList(_context.CardApplication, "ID", "ID");
            return View();
        }

        // POST: CardApplicationResults/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CardID,ApplicationID,CardName,Apr,PromotionalMessage,Accepted")] CardApplicationResult cardApplicationResult)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cardApplicationResult);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CardID"] = new SelectList(_context.Card, "ID", "ID", cardApplicationResult.CardID);
            ViewData["ApplicationID"] = new SelectList(_context.CardApplication, "ID", "ID", cardApplicationResult.ApplicationID);
            return View(cardApplicationResult);
        }

        // GET: CardApplicationResults/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardApplicationResult = await _context.CardApplicationResult.SingleOrDefaultAsync(m => m.ID == id);
            if (cardApplicationResult == null)
            {
                return NotFound();
            }
            ViewData["CardID"] = new SelectList(_context.Card, "ID", "ID", cardApplicationResult.CardID);
            ViewData["ApplicationID"] = new SelectList(_context.CardApplication, "ID", "ID", cardApplicationResult.ApplicationID);
            return View(cardApplicationResult);
        }

        // POST: CardApplicationResults/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("ID,CardID,ApplicationID,CardName,Apr,PromotionalMessage,Accepted")] CardApplicationResult cardApplicationResult)
        {
            if (id != cardApplicationResult.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cardApplicationResult);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CardApplicationResultExists(cardApplicationResult.ID))
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
            ViewData["CardID"] = new SelectList(_context.Card, "ID", "ID", cardApplicationResult.CardID);
            ViewData["ApplicationID"] = new SelectList(_context.CardApplication, "ID", "ID", cardApplicationResult.ApplicationID);
            return View(cardApplicationResult);
        }

        // GET: CardApplicationResults/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cardApplicationResult = await _context.CardApplicationResult
                .Include(c => c.Card)
                .Include(c => c.CardApplication)
                .SingleOrDefaultAsync(m => m.ID == id);
            if (cardApplicationResult == null)
            {
                return NotFound();
            }

            return View(cardApplicationResult);
        }

        // POST: CardApplicationResults/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var cardApplicationResult = await _context.CardApplicationResult.SingleOrDefaultAsync(m => m.ID == id);
            _context.CardApplicationResult.Remove(cardApplicationResult);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CardApplicationResultExists(long id)
        {
            return _context.CardApplicationResult.Any(e => e.ID == id);
        }*/
    }
}

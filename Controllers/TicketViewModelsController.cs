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
    public class TicketViewModelsController : Controller
    {
        private readonly MvcMovieContext _context;

        public TicketViewModelsController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: TicketViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.TicketViewModel.ToListAsync());
        }

        // GET: TicketViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketViewModel = await _context.TicketViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketViewModel == null)
            {
                return NotFound();
            }

            return View(ticketViewModel);
        }

        // GET: TicketViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TicketViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,MovieId")] TicketViewModel ticketViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticketViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticketViewModel);
        }

        // GET: TicketViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketViewModel = await _context.TicketViewModel.FindAsync(id);
            if (ticketViewModel == null)
            {
                return NotFound();
            }


            return View(ticketViewModel);
        }

        // POST: TicketViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,MovieId")] TicketViewModel ticketViewModel)
        {
            if (id != ticketViewModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticketViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketViewModelExists(ticketViewModel.Id))
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
            return View(ticketViewModel);
        }

        // GET: TicketViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticketViewModel = await _context.TicketViewModel
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ticketViewModel == null)
            {
                return NotFound();
            }

            return View(ticketViewModel);
        }

        // POST: TicketViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticketViewModel = await _context.TicketViewModel.FindAsync(id);
            _context.TicketViewModel.Remove(ticketViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketViewModelExists(int id)
        {
            return _context.TicketViewModel.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Demo_MVC.Data;
using Demo_MVC.Models;

namespace Demo_MVC.Controllers
{
    public class LeaveTypeClassesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveTypeClassesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveTypeClasses
        public async Task<IActionResult> Index()
        {
            return View(await _context.leaveTypeClass.ToListAsync());
        }

        // GET: LeaveTypeClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypeClass = await _context.leaveTypeClass
                .FirstOrDefaultAsync(m => m.LeaveTypeID == id);
            if (leaveTypeClass == null)
            {
                return NotFound();
            }

            return View(leaveTypeClass);
        }

        // GET: LeaveTypeClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypeClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveTypeID,LeaveType")] LeaveTypeClass leaveTypeClass)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveTypeClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypeClass);
        }

        // GET: LeaveTypeClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypeClass = await _context.leaveTypeClass.FindAsync(id);
            if (leaveTypeClass == null)
            {
                return NotFound();
            }
            return View(leaveTypeClass);
        }

        // POST: LeaveTypeClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveTypeID,LeaveType")] LeaveTypeClass leaveTypeClass)
        {
            if (id != leaveTypeClass.LeaveTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveTypeClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypeClassExists(leaveTypeClass.LeaveTypeID))
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
            return View(leaveTypeClass);
        }

        // GET: LeaveTypeClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypeClass = await _context.leaveTypeClass
                .FirstOrDefaultAsync(m => m.LeaveTypeID == id);
            if (leaveTypeClass == null)
            {
                return NotFound();
            }

            return View(leaveTypeClass);
        }

        // POST: LeaveTypeClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveTypeClass = await _context.leaveTypeClass.FindAsync(id);
            _context.leaveTypeClass.Remove(leaveTypeClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypeClassExists(int id)
        {
            return _context.leaveTypeClass.Any(e => e.LeaveTypeID == id);
        }
    }
}

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
    public class LeavesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeavesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Leaves
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.leaves.Include(l => l.LeaveTypeClass).Include(l => l.Users);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Leaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaves = await _context.leaves
                .Include(l => l.LeaveTypeClass)
                .Include(l => l.Users)
                .FirstOrDefaultAsync(m => m.LeaveID == id);
            if (leaves == null)
            {
                return NotFound();
            }

            return View(leaves);
        }

        // GET: Leaves/Create
        public IActionResult Create()
        {
            ViewData["LeaveTypeID"] = new SelectList(_context.leaveTypeClass, "LeaveTypeID", "LeaveTypeID");
            ViewData["UserID"] = new SelectList(_context.users, "UserID", "UserID");
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveID,UserID,LeaveTypeID,Noofdays,LeaveReason,LeaveStatus")] Leaves leaves)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaves);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaveTypeID"] = new SelectList(_context.leaveTypeClass, "LeaveTypeID", "LeaveTypeID", leaves.LeaveTypeID);
            ViewData["UserID"] = new SelectList(_context.users, "UserID", "UserID", leaves.UserID);
            return View(leaves);
        }

        // GET: Leaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaves = await _context.leaves.FindAsync(id);
            if (leaves == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeID"] = new SelectList(_context.leaveTypeClass, "LeaveTypeID", "LeaveTypeID", leaves.LeaveTypeID);
            ViewData["UserID"] = new SelectList(_context.users, "UserID", "UserID", leaves.UserID);
            return View(leaves);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveID,UserID,LeaveTypeID,Noofdays,LeaveReason,LeaveStatus")] Leaves leaves)
        {
            if (id != leaves.LeaveID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaves);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeavesExists(leaves.LeaveID))
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
            ViewData["LeaveTypeID"] = new SelectList(_context.leaveTypeClass, "LeaveTypeID", "LeaveTypeID", leaves.LeaveTypeID);
            ViewData["UserID"] = new SelectList(_context.users, "UserID", "UserID", leaves.UserID);
            return View(leaves);
        }

        // GET: Leaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaves = await _context.leaves
                .Include(l => l.LeaveTypeClass)
                .Include(l => l.Users)
                .FirstOrDefaultAsync(m => m.LeaveID == id);
            if (leaves == null)
            {
                return NotFound();
            }

            return View(leaves);
        }

        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaves = await _context.leaves.FindAsync(id);
            _context.leaves.Remove(leaves);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeavesExists(int id)
        {
            return _context.leaves.Any(e => e.LeaveID == id);
        }
    }
}

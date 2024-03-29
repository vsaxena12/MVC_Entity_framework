﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LeaveBased_RoleBased.Data;
using LeaveBased_RoleBased.Models;
using Microsoft.AspNetCore.Authorization;

namespace LeaveBased_RoleBased.Controllers
{
    public class LeavesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeavesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Leaves
        [Authorize(Roles = "Admin,Manager,User")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Leaves.Include(l => l.LeaveTypeClass);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Leaves/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaves = await _context.Leaves
                .Include(l => l.LeaveTypeClass)
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
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveTypes, "LeaveTypeID", "LeaveTypeID");
            return View();
        }

        // POST: Leaves/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveID,Id,LeaveTypeID,Noofdays,LeaveReason,LeaveStatus")] Leaves leaves)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaves);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveTypes, "LeaveTypeID", "LeaveTypeID", leaves.LeaveTypeID);
            return View(leaves);
        }

        [Authorize(Roles = "Admin,Manager")]
        // GET: Leaves/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaves = await _context.Leaves.FindAsync(id);
            if (leaves == null)
            {
                return NotFound();
            }
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveTypes, "LeaveTypeID", "LeaveTypeID", leaves.LeaveTypeID);
            return View(leaves);
        }

        // POST: Leaves/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin,Manager")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveID,Id,LeaveTypeID,Noofdays,LeaveReason,LeaveStatus")] Leaves leaves)
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
            ViewData["LeaveTypeID"] = new SelectList(_context.LeaveTypes, "LeaveTypeID", "LeaveTypeID", leaves.LeaveTypeID);
            return View(leaves);
        }

        [Authorize(Roles = "Admin,Manager")]
        // GET: Leaves/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaves = await _context.Leaves
                .Include(l => l.LeaveTypeClass)
                .FirstOrDefaultAsync(m => m.LeaveID == id);
            if (leaves == null)
            {
                return NotFound();
            }

            return View(leaves);
        }


        [Authorize(Roles = "Admin,Manager")]
        // POST: Leaves/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaves = await _context.Leaves.FindAsync(id);
            _context.Leaves.Remove(leaves);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeavesExists(int id)
        {
            return _context.Leaves.Any(e => e.LeaveID == id);
        }
    }
}

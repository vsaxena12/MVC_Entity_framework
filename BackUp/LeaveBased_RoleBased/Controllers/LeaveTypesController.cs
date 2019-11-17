using System;
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
    
    public class LeaveTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public LeaveTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: LeaveTypes
        public async Task<IActionResult> Index()
        {
            return View(await _context.LeaveTypes.ToListAsync());
        }

        // GET: LeaveTypes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypes = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.LeaveTypeID == id);
            if (leaveTypes == null)
            {
                return NotFound();
            }

            return View(leaveTypes);
        }

        // GET: LeaveTypes/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: LeaveTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LeaveTypeID,LeaveType")] LeaveTypes leaveTypes)
        {
            if (ModelState.IsValid)
            {
                _context.Add(leaveTypes);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(leaveTypes);
        }

        // GET: LeaveTypes/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypes = await _context.LeaveTypes.FindAsync(id);
            if (leaveTypes == null)
            {
                return NotFound();
            }
            return View(leaveTypes);
        }

        // POST: LeaveTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LeaveTypeID,LeaveType")] LeaveTypes leaveTypes)
        {
            if (id != leaveTypes.LeaveTypeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(leaveTypes);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LeaveTypesExists(leaveTypes.LeaveTypeID))
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
            return View(leaveTypes);
        }

        // GET: LeaveTypes/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var leaveTypes = await _context.LeaveTypes
                .FirstOrDefaultAsync(m => m.LeaveTypeID == id);
            if (leaveTypes == null)
            {
                return NotFound();
            }

            return View(leaveTypes);
        }

        // POST: LeaveTypes/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var leaveTypes = await _context.LeaveTypes.FindAsync(id);
            _context.LeaveTypes.Remove(leaveTypes);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LeaveTypesExists(int id)
        {
            return _context.LeaveTypes.Any(e => e.LeaveTypeID == id);
        }
    }
}

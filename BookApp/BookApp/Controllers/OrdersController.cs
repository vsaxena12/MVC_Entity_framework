using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookApp.Data;
using BookApp.Models;
using BookApp;

namespace BookApp.Controllers
{
    public class OrdersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OrdersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Orders
        [HttpGet]
        public async Task<IActionResult> Index(int? search)
        {

            var applicationDbContext = _context.Order.Include(o => o.Product);

            if (search != null)
            {
                return View(await applicationDbContext.Where(x => x.OrderID == search).ToListAsync());
            }

            return View(await applicationDbContext.ToListAsync());

        }
        //foreach (Orders o in applicationDbContext)
        //{
        //    if (search == o.OrdersID)
        //    {
        //        //return View();
        //    }
        //}



        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Orders = await _context.Order
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (Orders == null)
            {
                return NotFound();
            }

            return View(Orders);
        }

        // GET: Orders/Create
        public IActionResult Create()
        {
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName");
            return View();
        }

        // POST: Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderID,CustomerName,Address,PhoneNumber,ProductID,OrdersQuantity")] Order Orders)
        {
            //var costTemp = 0;
            if (ModelState.IsValid)
            {

                _context.Add(Orders);
                await _context.SaveChangesAsync();
                var applicationDbContext = _context.Order.Include(o => o.Product);
                //if (!applicationDbContext.Any())
                //{
                //    if (Orders.ProductID == Orders.Product.ProductID)
                //    {
                //        Orders.FinalPrice = (int)(Orders.OrdersQuantity * Orders.Product.Cost);
                //    }
                //}
                //else
                //{

                foreach (Order o in applicationDbContext)
                {
                    if (o.ProductID == o.Product.ProductID)
                    {
                        Orders.FinalPrice = (int)(Orders.OrderQuantity * o.Product.Cost);
                    }
                }
                //}

                // Orders.FinalPrice = costTemp;
                _context.Update(Orders);

                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", Orders.ProductID);
            return View(Orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Orders = await _context.Order.FindAsync(id);
            if (Orders == null)
            {
                return NotFound();
            }
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", Orders.ProductID);
            return View(Orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrdersID,CustomerName,Address,PhoneNumber,ProductID,OrdersQuantity,FinalPrice")] Order Orders)
        {
            if (id != Orders.OrderID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(Orders.OrderID))
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
            ViewData["ProductID"] = new SelectList(_context.Product, "ProductID", "ProductName", Orders.ProductID);
            return View(Orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Orders = await _context.Order
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderID == id);
            if (Orders == null)
            {
                return NotFound();
            }

            return View(Orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Orders = await _context.Order.FindAsync(id);
            _context.Order.Remove(Orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Order.Any(e => e.OrderID == id);
        }
    }
}

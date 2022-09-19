using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cvecara.Data.Data;
using Cvecara.Data.Entities;
using Cvecara.Business.Managers.Contracts;

namespace Cvecara.Controllers
{
    public class ArrangementsController : Controller
    {
        private readonly IArrangementManager _manager;

        public ArrangementsController(IArrangementManager manager)
        {
            _manager = manager;
        }

        // GET: Arrangements
        public IActionResult Index()
        {
            return View(_manager.Get());
        }

        // GET: Arrangements/Details/5
        public IActionResult Details(int id)
        {
           return View(_manager.GetFirst(e => e.Id == id));
        }

        // GET: Arrangements/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Arrangements/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Description,ImagePath,Price")] Arrangement arrangement)
        {
            if (ModelState.IsValid)
            {
                _manager.Add(arrangement);
                
                return RedirectToAction(nameof(Index));
            }
            return View(arrangement);
        }

        // GET: Arrangements/Edit/5
        public IActionResult Edit(int id)
        {
            return View(_manager.GetFirst(e => e.Id == id));
        }

        // POST: Arrangements/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Description,ImagePath,Price")] Arrangement arrangement)
        {
            if (id != arrangement.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {              
                _manager.Update(arrangement);            
                return RedirectToAction(nameof(Index));
            }
            return View(arrangement);
        }

        // GET: Arrangements/Delete/5
        public IActionResult Delete(int id)
        {
            return View(_manager.GetFirst(e => e.Id == id));
        }

        // POST: Arrangements/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _manager.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}

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
using System.Linq.Expressions;
using Microsoft.AspNetCore.Authorization;

namespace Cvecara.Controllers
{
    [Authorize]
    public class ArrangementItemsController : Controller
    {
        private readonly IArrangementItemManager _arrangementItemManager;
        private readonly IArrangementManager _arrangementManager;
        private readonly IItemManager _itemManager;

        public ArrangementItemsController(IArrangementItemManager arrangementItemManager, 
            IArrangementManager arrangementManager,
            IItemManager itemManager)
        {
            _arrangementItemManager = arrangementItemManager;
            _arrangementManager = arrangementManager;
            _itemManager = itemManager;
        }

        // GET: ArrangementItems
        public IActionResult Index()
        {
            return View(_arrangementItemManager.Get(includes: new List<Expression<Func<ArrangementItem, object>>>{ 
                e => e.Item,
                e => e.Arrangement
            }));
        }

        // GET: ArrangementItems/Details/5
        public IActionResult Details(int arrangementId, int itemId)
        {
            return View(_arrangementItemManager.GetFirst(e => e.ArrangementId == arrangementId && e.ItemId == itemId, 
                includes: new List<Expression<Func<ArrangementItem, object>>>
            {
                e => e.Arrangement,
                e => e.Item
            }));
        }

        // GET: ArrangementItems/Create
        public IActionResult Create()
        {
            ViewData["ArrangementId"] = new SelectList(_arrangementManager.Get(), "Id", "Name");
            ViewData["ItemId"] = new SelectList(_itemManager.Get(), "Id", "Name");
            return View();
        }

        // POST: ArrangementItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("ArrangementId,ItemId,Quantity")] ArrangementItem arrangementItem)
        {
            if (ModelState.IsValid)
            {
                _arrangementItemManager.Add(arrangementItem);
                return RedirectToAction(nameof(Index));
            }
            ViewData["ArrangementId"] = new SelectList(_arrangementManager.Get(), "Id", "Name", arrangementItem.ArrangementId);
            ViewData["ItemId"] = new SelectList(_itemManager.Get(), "Id", "Name", arrangementItem.ItemId);
            return View(arrangementItem);
        }

        // GET: ArrangementItems/Edit/5
        public IActionResult Edit(int arrangementId, int itemId)
        {
            var arrangementItem = _arrangementItemManager.GetFirst(e => e.ArrangementId == arrangementId && e.ItemId == itemId);

            ViewData["ArrangementId"] = new SelectList(_arrangementManager.Get(), "Id", "Name", arrangementItem.ArrangementId);
            ViewData["ItemId"] = new SelectList(_itemManager.Get(), "Id", "Name", arrangementItem.ItemId);
            return View(arrangementItem);
        }

        // POST: ArrangementItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ArrangementId,ItemId,Quantity")] ArrangementItem arrangementItem)
        {
            if (ModelState.IsValid)
            {
                _arrangementItemManager.Update(arrangementItem);               
                return RedirectToAction(nameof(Index));
            }

            ViewData["ArrangementId"] = new SelectList(_arrangementManager.Get(), "Id", "Name", arrangementItem.ArrangementId);
            ViewData["ItemId"] = new SelectList(_itemManager.Get(), "Id", "Name", arrangementItem.ItemId);
            return View(arrangementItem);
        }

        // GET: ArrangementItems/Delete/5
        public IActionResult Delete(int arrangementId, int itemId)
        {

            var arrangementItem = _arrangementItemManager.GetFirst(e => e.ArrangementId == arrangementId && e.ItemId == itemId,
                includes: new List<Expression<Func<ArrangementItem, object>>>
                {
                    e => e.Arrangement,
                    e => e.Item
                });

            return View(arrangementItem);
        }

        // POST: ArrangementItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed([Bind("ArrangementId,ItemId,Quantity")] ArrangementItem arrangementItem)
        {
            _arrangementItemManager.Remove(arrangementItem.ArrangementId, arrangementItem.ItemId);
            return RedirectToAction(nameof(Index));
        }
    }
}

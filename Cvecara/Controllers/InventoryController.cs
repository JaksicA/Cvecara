using Cvecara.Business.Managers.Contracts;
using Cvecara.Data.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Cvecara.Controllers
{
    [Authorize(Roles = Roles.Employee)]
    public class InventoryController : Controller
    {
        private readonly IInventoryManager _inventoryManager;
        private readonly IItemManager _itemManager;

        public InventoryController(IInventoryManager inventoryManager, IItemManager itemManager)
        {
            _inventoryManager = inventoryManager;
            _itemManager = itemManager;
        }
        // GET: InventoryController
        public ActionResult Index()
        {
            var includes = new List<Expression<Func<Inventory, object>>>
            {
                e => e.Item
            };

            return View(_inventoryManager.Get(includes: includes));
        }

        // GET: InventoryController/Create
        public ActionResult Create()
        {
            var inventory = _inventoryManager.Get();
            ViewBag.Items = new SelectList(_itemManager.Get(e => !inventory.Any(x => e.Id == x.Id)), nameof(Item.Id), nameof(Item.Name));
            return View();
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Inventory inventoryItem)
        {
            try
            {
                _inventoryManager.Add(inventoryItem);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                var inventory = _inventoryManager.Get();
                ViewBag.Items = new SelectList(_itemManager.Get(e => !inventory.Any(x => e.Id == x.Id)), nameof(Item.Id), nameof(Item.Name));
                return View();
            }
        }

        // GET: InventoryController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_inventoryManager.GetFirst(e => e.Id == id, new List<Expression<Func<Inventory, object>>>
            {
                e => e.Item
            }));
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Inventory inventory)
        {
            try
            {
                _inventoryManager.Update(inventory);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_inventoryManager.GetFirst(e => e.Id == id, new List<Expression<Func<Inventory, object>>>
                {
                    e => e.Item
                }));
            }
        }

        // GET: InventoryController/Delete/5
        public ActionResult Delete(int id)
        {

            return View(_inventoryManager.GetFirst(e => e.Id == id, new List<Expression<Func<Inventory, object>>>
            {
                e => e.Item
            }));
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _inventoryManager.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_inventoryManager.GetFirst(e => e.Id == id, new List<Expression<Func<Inventory, object>>>
                {
                    e => e.Item
                }));
            }
        }
    }
}

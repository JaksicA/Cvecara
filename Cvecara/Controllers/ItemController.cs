using Cvecara.Business.Managers.Contracts;
using Cvecara.Data.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cvecara.Controllers
{
    public class ItemController : Controller
    {
        private readonly IItemManager _manager;

        public ItemController(IItemManager manager)
        {
            _manager = manager;
        }

        // GET: ItemController
        public ActionResult Index()
        {
            return View(_manager.Get());
        }

        // GET: ItemController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ItemController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Item item)
        {
            try
            {
                _manager.Add(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ItemController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_manager.GetFirst(e => e.Id == id));
        }

        // POST: ItemController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Item item)
        {
            try
            {
                _manager.Update(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_manager.GetFirst(e => e.Id == id));
            }
        }

        // GET: ItemController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_manager.GetFirst(e => e.Id == id));
        }

        // POST: ItemController/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            try
            {
                _manager.Remove(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(_manager.GetFirst(e => e.Id == id));
            }
        }
    }
}

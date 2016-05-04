using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElevenNote.Services;
using Microsoft.AspNet.Identity;
using SalesTracker.Models;
using WebApplication1;

namespace ElevenNote.Web.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private readonly Lazy<SalesService> _svc;

        public SalesController()
        {
            _svc =
                new Lazy<SalesService>(
                    () =>
                    {
                        var userId = Guid.Parse(User.Identity.GetUserId());
                        return new SalesService(userId);
                    });
        }

        public ActionResult Index()
        {
            var notes = _svc.Value.GetSales();

            return View(notes);
        }

        public ActionResult Create()
        {
            var vm = new SalesCreateData();

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SalesCreateData vm)
        {
            if (!ModelState.IsValid) return View(vm);

            if (!_svc.Value.CreateSales(vm))
            {
                ModelState.AddModelError("", "Unable to create sale item.");
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(int id)
        {
            var sale = _svc.Value.GetSalesById(id);

            return View(sale);
        }

        public ActionResult Edit(int id)
        {
            var detail = _svc.Value.GetSalesById(id);
            var sale =
                new SalesEditModel
                {
                    SalesId = detail.SalesId,
                    Date = detail.Date,
                    Client = detail.Client,
                    Address = detail.Address,
                    SalesPrice = detail.SalesPrice,
                    Commission = detail.Commission,
                    Source = detail.Source
                };

            return View(sale);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SalesEditModel vm)
        {
            if (!ModelState.IsValid) return View(vm);

            if (!_svc.Value.UpdateSales(vm))
            {
                ModelState.AddModelError("", "Unable to update note");
                return View(vm);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult DeleteGet(int id)
        {
            var detail = _svc.Value.GetSalesById(id);

            return View(detail);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            _svc.Value.DeleteSales(id);

            return RedirectToAction("Index");
        }
    }
}

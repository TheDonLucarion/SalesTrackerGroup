using System;
using System.Linq;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using SalesTracker.Models;
using SalesTracker.Services;
using SalesTracker.Data;
using PagedList;

namespace SalesTracker.Controllers
{
    [Authorize]
    public class SalesController : Controller
    {
        private readonly Lazy<SalesService> _svc;
        private SalesTrackerDbContext db = new SalesTrackerDbContext();

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

        public ActionResult Index(string sortOrder, string curentFilter, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.DateSort = sortOrder == "Date" ? "DateDesc" : "Date";
            ViewBag.FirstNameSort = String.IsNullOrEmpty(sortOrder) ? "FirstNameDesc" : "";
            ViewBag.LastNameSort = sortOrder == "LastName" ? "LastNameDesc" : "LastName";
            ViewBag.AddressSort = sortOrder == "Address" ? "AdressDesc" : "Address";
            //ViewBag.LastNameSort = String.IsNullOrEmpty(sortOrder) ? "LastNameDesc" : "LastName";
            //ViewBag.AddressSort = String.IsNullOrEmpty(sortOrder) ? "AdressDesc" : "Address";
            //ViewBag.SourceSort = String.IsNullOrEmpty(sortOrder) ? "SourceDesc" : "Source";


            ViewBag.SalesPriceSort = sortOrder == "SalesPrice" ? "SalesPriceDesc" : "SalesPrice";
            ViewBag.CommissionSort = sortOrder == "Commission" ? "CommissionDesc" : "Commission";
            ViewBag.SourceSort = sortOrder == "Source" ? "SourceDesc" : "Source";



            var sales = from s in db.Sales
                        select s;
            //Sorting
            switch (sortOrder)
            {
                case "FirstNameDesc":
                    sales = sales.OrderByDescending(s => s.FirstName);
                    break;
                case "Date":
                    sales = sales.OrderBy(s => s.Date);
                    break;
                case "DateDesc":
                    sales = sales.OrderByDescending(s => s.Date);
                    break;
                case "LastName":
                    sales = sales.OrderBy(s => s.LastName);
                    break;
                case "LastNameDesc":
                    sales = sales.OrderByDescending(s => s.LastName);
                    break;
                case "Address":
                    sales = sales.OrderBy(s => s.Address);
                    break;
                case "AddressDesc":
                    sales = sales.OrderByDescending(s => s.Address);
                    break;
                case "SalesPrice":
                    sales = sales.OrderBy(s => s.SalesPrice);
                    break;
                case "SalesPriceDesc":
                    sales = sales.OrderByDescending(s => s.SalesPrice);
                    break;
                case "Commission":
                    sales = sales.OrderBy(s => s.Commission);
                    break;
                case "CommissionDesc":
                    sales = sales.OrderByDescending(s => s.Commission);
                    break;
                case "Source":
                    sales = sales.OrderBy(s => s.Source);
                    break;
                case "SourceDesc":
                    sales = sales.OrderByDescending(s => s.Source);
                    break;
                default:
                    sales = sales.OrderBy(s => s.FirstName);
                    break;
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            //var notes = _svc.Value.GetSales();
            return View(sales.ToPagedList(pageNumber, pageSize));
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
                    FirstName = detail.FirstName,
                    LastName = detail.LastName,
                    Address = detail.Address,
                    SalesPrice = detail.SalesPrice,
                    TotalCommission = detail.TotalCommission,
                    ThirdPartyReferral = detail.ThirdPartyReferral,
                    RoyaltyFee = detail.RoyaltyFee,
                    AgentSplit = detail.AgentSplit,
                    ReloSplit = detail.ReloSplit,
                    Base = detail.Base,
                    APCF = detail.APCF,
                    EnrollPCC = detail.EnrollPCC,
                    CharitbaleContribution = detail.CharitbaleContribution,
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceSystem.Application.Interfaces;
using InvoiceSystem.Domain.Entities;
using InvoiceSystem.Infrastructure.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace InvoiceSystem.WebUICore.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IItemsService _itemService;
        private readonly IStoreService _storeService;
        private readonly IUnitService _unitService;
        private readonly IInvoiceItemsService _invoiceItemsService;
        private readonly IInvoiceService _invoiceService;


        public InvoiceController(IUnitService unit , IStoreService store , 
            IItemsService item , IInvoiceItemsService invoiceItems , IInvoiceService invoice)
        {
            _itemService = item;
            _storeService = store;
            _unitService = unit;
            _invoiceItemsService = invoiceItems;
            _invoiceService = invoice;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CreateNewInvoice()
        {
            var model = new InvoiceViewModel();
            ViewBag.StoresList = _storeService.GetAllStores();
            return View(model);
        }

        public ActionResult AddNewInvoiceItemForm()
        {
            var invoiceItem = new InvoiceItemsViewModel();

            ViewBag.ItemsList = _itemService.GetAllItems();
            ViewBag.UnitList = _unitService.GetAllUnits();
            return PartialView("_InvoiceItemFormPartial", invoiceItem);
        }


        [HttpPost]
        public ActionResult AddNewInvoiceItem(InvoiceItemsViewModel model)
        {
            return Json(new { });
        }

        [HttpPost]
        public ActionResult AddNewInvoice(InvoiceViewModel model)
        {
            return Json(new { });
        }


        [HttpPost]
        public ActionResult LoadAllInvoiceItems()
        {
            string draw = Request.Form["draw"].FirstOrDefault();
            string start = Request.Form["start"].FirstOrDefault();
            string length = Request.Form["length"].FirstOrDefault();

            int take = length != null ? Convert.ToInt32(length) : 0;
            int skip = start != null ? Convert.ToInt32(start) : 0;

            int recordsCount = 0;

            var invoiceItems = _invoiceItemsService.GetAllInvoiceItemsDT(take, skip, out recordsCount);

            var toSerialize = new
            {
                draw = draw,
                recordsFiltered = recordsCount,
                recordsTotal = recordsCount,

                data = invoiceItems.Select(r => new
                {
                    ID = r.Id,
                    ItemName = _itemService.GetItemName((int)r.ItemId),
                    Unit = _unitService.GetUnitName((int)r.UnitId),
                    Price = r.Price,
                    ItemQty = r.ItemsQty,
                    Total = r.Total,
                    Discount = r.Discount,
                    Net = r.NetPrice
                }).AsQueryable()
            };

            return Json(toSerialize);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCServices;
using TCDBEntities;
using TownCleanWeb.Controllers;

namespace TownCleanWeb.Areas.Admin.Controllers
{
    [Authorize]
    public class QuotationController : BaseController
    {
        private IQuotationService _quotationService;

        public QuotationController(IQuotationService quotationService)
        {
            this._quotationService = quotationService;
        }
        // GET: Admin/Quotation
        public ActionResult QuotationList()
        {
            var quotationList = _quotationService.GetQuotationSummaryList().ToList();
            return View(quotationList);
        }

        public ActionResult QuotationDetails(int id)
        {
            var quotation = _quotationService.GetQuotationById(id);
            return View(quotation);
        }

        public ActionResult AddNewQuotation()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddNewQuotation(Quotation model)
        {
            int i = 0;
           if(!ModelState.IsValid)
           {
               return View(model);              
           }

            i = _quotationService.InsertQuotation(model);
            if (i > 0)
                return RedirectToAction("QuotationList");
            else
            {
                return View(model); 
            }            
        }
    }
}
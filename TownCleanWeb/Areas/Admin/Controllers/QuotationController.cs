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
            InsertQuotation quot = new InsertQuotation();
            quot.CustomerTypeID = null;
            quot.QuotationServiceTypeID = null;
            quot.CustomerID = null;
            quot.CustomerTypeList = new SelectList(_quotationService.GetCustomerTypeList(), "CustomerTypeID", "CustomerTypeName", quot.CustomerTypeID);
            quot.QuotationServiceTypeList = new SelectList(_quotationService.GetQuotationServiceTypeList(), "ServiceTypeID", "ServiceTypeName", quot.QuotationServiceTypeID);
            var custList = _quotationService.GetAllActiveCustomerByBranchId(1).Select(c => new { CustomerID = c.CustomerID, CustomerName = c.CustomerFirstName + " " + c.CustomerMidName + " " + c.CustomerLastName });
            quot.CustomerList = new SelectList(custList, "CustomerID", "CustomerName", quot.CustomerID);
            return View(quot);
        }

        [HttpPost]
        public ActionResult AddNewQuotation(InsertQuotation model)
        {
            int i = 0;
           if(!ModelState.IsValid)
           {
               return View(model);              
           }

           Quotation qc = new Quotation();
           qc.ContactName = model.ContactName;
           qc.Address = model.Address;
           qc.Phone = model.Phone;
           qc.Email = model.Email;
           qc.CustomerTypeID = Convert.ToInt32(model.CustomerTypeID);
           qc.QuotationServiceTypeID = Convert.ToInt32(model.QuotationServiceTypeID);
           qc.CustomerID = Convert.ToInt32(model.CustomerID);
           qc.BranchID = branchID;
           qc.CreatedBy = userName;
           if (model.IsExitingCustomer)
               qc.CustomerID = model.CustomerID;
           else
               qc.CustomerID = null;

            i = _quotationService.InsertQuotation(qc);
            if (i > 0)
                return RedirectToAction("AddItemsForQuotation", new { id = qc.QuotationID});
            else
            {
                return View(model); 
            }            
        }

        
        //[Route("QuotationNo/{id}")]
        public ActionResult AddItemsForQuotation(int id)        
        {
            Quotation qc = _quotationService.GetQuotationById(id);
            ViewBag.Qtc = qc;
            return View();
        }

        [HttpPost]
        public ActionResult AddItemsForQuotation(QuotationDetail quotationDetail)
        {
            return View();
        }
    }
}
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
    public class ExpenseController : BaseController
    {
        private IExpenseService _ExpenseService;

        public ExpenseController(IExpenseService ExpenseService)
        {
            this._ExpenseService = ExpenseService;
        }
        // GET: Admin/Expense
       

        public ActionResult ExpenseDetails(int id)
        {
            var Expense = _ExpenseService.GetExpenseById(id);
            return View(Expense);
        }

       

        [HttpPost]
        public ActionResult AddNewExpense(InsertExpense model)
        {
            int i = 0;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Expense qc = new Expense();
           
            qc.ExpenseName = model.ExpenseName;
            qc.ExpenseType = model.ExpenseType;
            qc.Amount = Convert.ToDecimal(model.Amount);
            qc.ExpenseDate = model.ExpenseDate;
            qc.Description = model.Description;
            qc.PaymentMode = model.PaymentMode;
            qc.Attachment_Url = model.Attachment_Url;
           qc.ExpenseID = Convert.ToInt32(model.CustomerID);
            qc.BranchID = branchID;
            qc.CreatedBy = userName;
            if (model.IsExitingExpense)
                qc.ExpenseName = model.ExpenseName;
            else
                qc.ExpenseName = null;

            i = _ExpenseService.InsertExpense(qc);
            if (i > 0)
                return RedirectToAction("AddItemsForExpense", new { id = qc.ExpenseID });
            else
            {
                return View(model);
            }
        }


        //[Route("ExpenseNo/{id}")]
        public ActionResult AddItemsForExpense(int id)
        {
            Expense qc = _ExpenseService.GetExpenseById(id);
            ViewBag.Qtc = qc;
            return View();
        }

        [HttpPost]
        public ActionResult AddItemsForExpense(Expense ExpenseDetail)
        {
            return View();
        }
    }
}
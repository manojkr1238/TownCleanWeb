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

        private TownClean_DBEntities db = new TownClean_DBEntities();

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
        public ActionResult AddNewExpense()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExpenseID,ExpenseName,ExpenseType,Amount,ExpenseDate,Description,PaymentMode,PaymentModeNo,Attachment_Url,BranchID,CreatedBy,CreatedDate,ModifiedBy,ModifiedDate,IsDeleted")] Expense expense)
        {
            if (ModelState.IsValid)
            {
                db.Expenses.Add(expense);
                db.SaveChanges();
                
            }

            ViewBag.BranchID = new SelectList(db.Branches, "BranchID", "BranchName", expense.BranchID);
            return View(expense);
        }



        public ActionResult ExpenseList()
        {
            var expenseList = _ExpenseService.GetExpenseSummaryList().ToList();
            return View(expenseList);
        }


       /* [HttpPost]
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

            qc.ExpenseDate = model.ExpenseDate;
            qc.Description = model.Description;
            qc.PaymentMode = model.PaymentMode;
            qc.Attachment_Url = model.Attachment_Url;
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
        }*/
    }




}

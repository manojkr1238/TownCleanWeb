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
       
        public ActionResult ExpenseList()
        {
            var expenseList = _ExpenseService.GetExpenseSummaryList().ToList();
            return View(expenseList);
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

            qc.ExpenseDate = model.ExpenseDate;
            qc.Description = model.Description;
            qc.PaymentMode = model.PaymentMode;
            qc.Attachment_Url = model.Attachment_Url;
            qc.BranchID = branchID;
            qc.CreatedBy = userName;
            qc.CreatedDate = DateTime.Now;            

            i = _ExpenseService.InsertExpense(qc);


            if (i > 0)
                return RedirectToAction("ExpenseList");
            else
            {
                return View(model);
            }
        }
    }




}

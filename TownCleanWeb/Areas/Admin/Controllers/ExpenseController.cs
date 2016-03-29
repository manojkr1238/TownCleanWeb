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

        public ActionResult AddNewExpense()
        {
            return View();
        }
        public ActionResult ExpenseList()
        {
            var quotationList = _expenseService.GetExpenseSummaryList().ToList();
            return View(expenseList);
        }
       

        [HttpPost]
        public ActionResult AddNewExpense(Expense model)
        {
            
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
           qc.ExpenseID = Convert.ToInt32(model.ExpenseID);
            qc.BranchID = branchID;
            qc.CreatedBy = userName;
           
                return View(model);
            }

      
    }


      
     
    }

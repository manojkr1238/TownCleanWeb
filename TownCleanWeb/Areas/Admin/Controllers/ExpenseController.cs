using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TCServices;
using TCDBEntities;

using TownCleanWeb.Controllers;
using OfficeOpenXml;
using System.IO;

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


        public ActionResult ExpenseList(string sortOrder, string searchString)
        {
            var expenseList = _ExpenseService.GetExpenseSummaryList().ToList();
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var Expenses = from s in db.Expenses
                           select s;

            switch (sortOrder)
            {
                case "name_desc":
                    Expenses = Expenses.OrderByDescending(s => s.ExpenseName);
                    break;
                case "Date":
                    Expenses = Expenses.OrderBy(s => s.ExpenseType);
                    break;
                case "date_desc":
                    Expenses = Expenses.OrderByDescending(s => s.ExpenseDate);
                    break;
                default:
                    Expenses = Expenses.OrderBy(s => s.PaymentMode);
                    break;
            }
            return View(expenseList);
        }
     /*  public ViewResult Index(string Expenses, string strSearch)
       {
           //Select all Book records
           var expenses = from b in db.Expenses
                          select b;

           //Get list of Book publisher
           var expenseList = from c in expenses
                             orderby c.ExpenseName
                             select c.ExpenseType;

           //Set distinct list of publishers in ViewBag property
           ViewBag.Expenses = new SelectList(expenseList.Distinct());

           //Search records by Book Name 
           if (!string.IsNullOrEmpty(strSearch))
               Expenses = Expenses.Where(m => m.ExpenseName.Contains(strSearch));

           //Search records by Publisher
           if (!string.IsNullOrEmpty(Expenses))
               Expenses = Expenses.Where(m => m.CompareTo == Expenses);
           return View(books);
       }*/
        public ActionResult ExpenseReport()
        {
            
            return View();
        }

       public ActionResult DownloadExpenseExcel()
        {
            var expenseList = _ExpenseService.GetExpenseSummaryList().ToList();
            using (ExcelPackage pck = new ExcelPackage())
            {
                ExcelWorksheet ws = pck.Workbook.Worksheets.Add("Expenses");
                ws.Cells["A1"].LoadFromCollection(expenseList, true);
                // Load your collection "accounts"

                Byte[] fileBytes = pck.GetAsByteArray();
                Response.Clear();
                Response.Buffer = true;
                Response.AddHeader("content-disposition", "attachment;filename=DataTable.xlsx");
                // Replace filename with your custom Excel-sheet name.

                Response.Charset = "";
                Response.ContentType = "application/vnd.ms-excel";
                StringWriter sw = new StringWriter();
                Response.BinaryWrite(fileBytes);
                Response.End();

            }

            return RedirectToAction("DownloadExpenseExcel");
        }


         /* IEnumerable<object[]> GetAsEnumerable(MultiDimDictList table)
{
  yield return table.Columns.Select(i => (object)i.Name).ToArray();

  foreach (var row in table)
  {
    yield return table.Columns.Select(i => (object)row[i.Name]).ToArray();
  }
}

        }*/


        [Route("AddNewExpense")]
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
            HttpPostedFileBase file = Request.Files["ImageData"];
            if (file != null)
            {
                file.SaveAs(HttpContext.Server.MapPath("~/Images/")
                                                      + file.FileName);
               
            }
            

            qc.PaymentModeNo = model.PaymentModeNo;
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

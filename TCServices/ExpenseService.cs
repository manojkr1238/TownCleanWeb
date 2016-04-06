using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDBEntities;
using TCRepositories;
using System.Data.Entity;
using System.Web.Mvc;

namespace TCServices
{
    public class ExpenseService : IExpenseService
    {
        GenericRepository<Expense> _genericRepository;
         public ExpenseService(DbContext dbContext)
        {
            this._genericRepository = new GenericRepository<Expense>(dbContext);
           }


         IQueryable<Expense> IExpenseService.GetAllExpenses()
         {
             return _genericRepository.GetAll();
         }

          Expense IExpenseService.GetExpenseById(int id)
         {
             return _genericRepository.GetById(id);
         }

          IEnumerable<Expense> IExpenseService.GetAllExpenseListBranchWise(int branchid)
         {
             return _genericRepository.GetAll().Where(b => b.BranchID == branchid);
         }

          int IExpenseService.DeleteExpense(int id)
         {
             return _genericRepository.Delete(id);        
         }

          int IExpenseService.UpdateExpense(Expense expense)
         {
             return _genericRepository.Update(expense);
         }

          int IExpenseService.InsertExpense(Expense expense)
         {
             return _genericRepository.Insert(expense);
         }



          IEnumerable<ExpenseSummary> IExpenseService.GetExpenseSummaryList()
          {
              return _genericRepository.GetAll().Select(e => new ExpenseSummary
              {
                  ExpenseID = e.ExpenseID,
                  ExpenseName = e.ExpenseName,
                  ExpenseType = e.ExpenseType,
                  
                 
                  ExpenseDate = e.ExpenseDate,
                  Description = e.Description,
                  PaymentMode = e.PaymentMode,
                  PaymentModeNo = e.PaymentModeNo
                 
              });
          }





         
    }
}

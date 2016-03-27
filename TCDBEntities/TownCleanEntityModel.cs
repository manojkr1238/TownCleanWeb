using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace TCDBEntities
{
    public class QuotationSummary
    {
        public int QuotationID { get; set; }
        public string QuotationNo { get; set; }
        public string ContactName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime QuotationDate { get; set; }
        public decimal? TotalVolume { get; set; }
        public decimal? TotalPrice { get; set; }
        public bool IsSent { get; set; }
    }

    public class InsertQuotation
    {
        [Required]
        public string ContactName { get; set; }

        [Required]
        public string Address { get; set; }

        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string CustomerTypeID { get; set; }
        [Required]
        public string QuotationServiceTypeID { get; set; }

        public bool IsExitingCustomer { get; set; }

        public int? CustomerID { get; set; }

        //[Required]
        //public int BranchID { get; set; }

        //[Required]
        //public string CreatedBy { get; set; }

        public SelectList CustomerTypeList { get; set; }
        public SelectList QuotationServiceTypeList { get; set; }
        public SelectList CustomerList { get; set; }

    }
    public class ExpenseSummary
    {
        public int ExpenseID { get; set; }
        public string ExpenseName { get; set; }
        public string ExpenseType { get; set; }
        public string Amount { get; set; }
        public string ExpenseDate { get; set; }
        public string Description { get; set; }
        public DateTime PaymentMode { get; set; }
        public decimal? Attachment_Url { get; set; }
       
    }
    public class InsertExpense
    {
        [Required]
        public string ExpenseName { get; set; }

        [Required]
        public string ExpenseType { get; set; }

        public string Amount { get; set; }

        [Required]
        public string ExpenseDate { get; set; }

        [Required]
        public string PaymentMode { get; set; }
        [Required]
        public string Description { get; set; }

        public string Attachment_Url { get; set; }

        public int? CustomerID { get; set; }

        //[Required]
        //public int BranchID { get; set; }

        //[Required]
        //public string CreatedBy { get; set; }

        public SelectList CustomerTypeList { get; set; }
        public SelectList ExpenseServiceTypeList { get; set; }
        public SelectList CustomerList { get; set; }


        public bool IsExitingExpense { get; set; }
    }
}

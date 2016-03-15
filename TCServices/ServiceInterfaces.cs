using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDBEntities;

namespace TCServices
{
    public interface IQuotationService
    {
        IQueryable<Quotation_Details> GetAllQuotations();
        Quotation_Details GetQuotationById(int id);
        IEnumerable<Quotation_Details> GetAllQuotationListBranchWise(int branchid);
        int DeleteQuotation(int id);
        int UpdateQuotation(Quotation_Details quotation);
        int InsertQuotation(Quotation_Details quotation);
    }
}

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
        IQueryable<Quotation> GetAllQuotations();
        Quotation GetQuotationById(int id);
        IEnumerable<Quotation> GetAllQuotationListBranchWise(int branchid);
        int DeleteQuotation(int id);
        int UpdateQuotation(Quotation quotation);
        int InsertQuotation(Quotation quotation);
        IEnumerable<QuotationSummary> GetQuotationSummaryList();
    }
}

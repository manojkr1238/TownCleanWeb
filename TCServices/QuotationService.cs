using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDBEntities;
using TCRepositories;
using System.Data.Entity;

namespace TCServices
{
    
    public class QuotationService : IQuotationService
    {
        GenericRepository<Quotation> _genericRepository;       

        public QuotationService(DbContext dbContext)
        {
            this._genericRepository = new GenericRepository<Quotation>(dbContext);
        }

        public IQueryable<Quotation> GetAllQuotations()
        {
           return  _genericRepository.GetAll();
        }
        public Quotation GetQuotationById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public IEnumerable<Quotation> GetAllQuotationListBranchWise(int branchid)
        {
            return _genericRepository.GetAll().Where(b => b.BranchID == branchid);
        }

        public int DeleteQuotation(int id)
        {
            return _genericRepository.Delete(id);             
        }

        public int UpdateQuotation(Quotation quotation)
        {
            return _genericRepository.Update(quotation);
        }

        public int InsertQuotation(Quotation quotation)
        {
            return _genericRepository.Insert(quotation);
        }

        public IEnumerable<QuotationSummary> GetQuotationSummaryList()
        {
            return _genericRepository.GetAll().Select(q => new QuotationSummary
            {
                QuotationID = q.QuotationID,
                QuotationNo = q.QuotationNo,
                ContactName = q.ContactName,
                Address = "Address " + q.Address + " Email " + q.Email + "Phone " + q.Phone,
                QuotationDate = q.CreatedDate,
                TotalVolume = q.QuotationDetails.Sum(l => l.TankVolume),
                TotalPrice = q.QuotationDetails.Sum( p => p.TotalPrice)
            });
        }
         
    }
}

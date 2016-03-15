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
        GenericRepository<Quotation_Details> _genericRepository;       

        public QuotationService(DbContext dbContext)
        {
            this._genericRepository = new GenericRepository<Quotation_Details>(dbContext);
        }

        public IQueryable<Quotation_Details> GetAllQuotations()
        {
           return  _genericRepository.GetAll();
        }
        public Quotation_Details GetQuotationById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public IEnumerable<Quotation_Details> GetAllQuotationListBranchWise(int branchid)
        {
            return _genericRepository.GetAll().Where(b => b.Branch_ID == branchid);
        }

        public int DeleteQuotation(int id)
        {
            return _genericRepository.Delete(id);             
        }

        public int UpdateQuotation(Quotation_Details quotation)
        {
            return _genericRepository.Update(quotation);
        }

        public int InsertQuotation(Quotation_Details quotation)
        {
            return _genericRepository.Insert(quotation);
        }      
         
    }
}

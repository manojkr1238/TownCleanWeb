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
    
    public class QuotationService : IQuotationService
    {
        GenericRepository<Quotation> _genericRepository;
        GenericRepository<CustomerType> _genericRepositoryCustomerType;
        GenericRepository<QuotationServiceType> _genericRepositoryQuotationServiceType;
        GenericRepository<Customer> _genericRepositoryCustomer;

        public QuotationService(DbContext dbContext)
        {
            this._genericRepository = new GenericRepository<Quotation>(dbContext);
            this._genericRepositoryCustomerType = new GenericRepository<CustomerType>(dbContext);
            this._genericRepositoryQuotationServiceType = new GenericRepository<QuotationServiceType>(dbContext);
            this._genericRepositoryCustomer = new GenericRepository<Customer>(dbContext);
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
            QuotationServiceType qtcs = GetQuotationServiceTypeList().Where(c => c.ServiceTypeID == quotation.QuotationServiceTypeID).FirstOrDefault();
            quotation.QuotationNo = "TC/QC/" + qtcs.ShortCode +"/"+ (GetMaximumQuotationID() + 1).ToString() + "/" + DateTime.Now.ToString("yyyyMMdd");
            quotation.QuotationSubjectLine = "Quotation For " + qtcs.ServiceTypeName + " - " + quotation.ContactName;
            quotation.CreatedDate = DateTime.Now;
            return _genericRepository.Insert(quotation);
        }
        
        public IEnumerable<QuotationSummary> GetQuotationSummaryList()
        {
            return _genericRepository.GetAll().Select(q => new QuotationSummary
            {
                QuotationID = q.QuotationID,
                QuotationNo = q.QuotationNo,
                ContactName = q.ContactName,
                Address = q.Address,
                Email = q.Email,
                Phone = q.Phone,
                QuotationDate = q.CreatedDate,
                TotalVolume = q.QuotationDetails.Sum(l => l.TankVolume),
                TotalPrice = q.QuotationDetails.Sum( p => p.TotalPrice)                
            });
        }

        public IEnumerable<CustomerType> GetCustomerTypeList()
        {
            return _genericRepositoryCustomerType.GetAll();
        }
        public IEnumerable<QuotationServiceType> GetQuotationServiceTypeList()
        {
            return _genericRepositoryQuotationServiceType.GetAll();
        }
        public IEnumerable<Customer> GetAllActiveCustomerByBranchId(int branchid)
        {
            return _genericRepositoryCustomer.GetAll().Where(d => d.BranchID == branchid && d.IsDeleted == false);            
        }
        public int GetMaximumQuotationID()
        {          
           if (_genericRepository.GetAll().Count() <= 0)
               return 0;
           else
               return _genericRepository.GetAll().Max(q => q.QuotationID);
        }

         
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TCDBEntities;
using TCRepositories;

namespace TCServices
{
    public class QuotationServiceTypeService : IQuotationServiceTypeService
    {
        GenericRepository<QuotationServiceType> _genericRepository;

        public QuotationServiceTypeService(DbContext dbContext)
        {
            this._genericRepository = new GenericRepository<QuotationServiceType>(dbContext);
        }
        public IQueryable<QuotationServiceType> GetAllQuotationServices()
        {
            return _genericRepository.GetAll();
        }
        public QuotationServiceType GetQuotationServiceById(int id)
        {
            return _genericRepository.GetById(id);
        }

        public int DeleteQuotationService(int id)
        {
            return _genericRepository.Delete(id);
        }

        public int UpdateQuotationService(QuotationServiceType quotationService)
        {
            return _genericRepository.Update(quotationService);
        }

        public int InsertQuotationService(QuotationServiceType quotationService)
        {
            return _genericRepository.Insert(quotationService);
        }
    }
}

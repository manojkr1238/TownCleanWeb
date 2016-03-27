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
    class CustomerTypeService : ICustomerTypeService
    { 
        GenericRepository<CustomerType> _genericRepository;

        public CustomerTypeService(DbContext dbContext)
        {
            this._genericRepository = new GenericRepository<CustomerType>(dbContext);
        }
        public IQueryable<CustomerType> GetAllCustomerTypes()
        {
            return _genericRepository.GetAll();
        }
        public CustomerType GetCustomerTypeById(int id)
        {
            return _genericRepository.GetById(id);
        }
        public int DeleteCustomerType(int id)
        {
            return _genericRepository.Delete(id);
        }
        public int UpdateCustomerType(CustomerType customerType)
        {
            return _genericRepository.Update(customerType);
        }
        public int InsertCustomerType(CustomerType customerType)
        {
            return _genericRepository.Insert(customerType);
        }
    }
}

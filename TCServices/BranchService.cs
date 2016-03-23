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
    public class BranchService :  IBranchService
    {
        GenericRepository<Branch> _genericRepository;

        public BranchService(DbContext dbContext)
        {
            this._genericRepository = new GenericRepository<Branch>(dbContext);
        }

        public IQueryable<Branch> GetAllBranchs()
        {
           return  _genericRepository.GetAll();
        }
        public Branch GetBranchById(int id)
        {
            return _genericRepository.GetById(id);
        }
        public int DeleteBranch(int id)
        {
            return _genericRepository.Delete(id);     
        }
        public int UpdateBranch(Branch branch)
        {
            return _genericRepository.Update(branch);
        }
        public int InsertBranch(Branch branch)
        {
            return _genericRepository.Insert(branch);
        }
    }
}

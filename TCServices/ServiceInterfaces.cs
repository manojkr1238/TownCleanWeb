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

    public interface IQuotationServiceTypeService
    {
        IQueryable<QuotationServiceType> GetAllQuotationServices();
        QuotationServiceType GetQuotationServiceById(int id);
        //IEnumerable<QuotationServiceMaster> GetAllQuotationServiceListBranchWise(int branchid);
        int DeleteQuotationService(int id);
        int UpdateQuotationService(QuotationServiceType quotation);
        int InsertQuotationService(QuotationServiceType quotation);        
    }

    public interface IBranchService
    {
        IQueryable<Branch> GetAllBranchs();
        Branch GetBranchById(int id);
        int DeleteBranch(int id);
        int UpdateBranch(Branch quotation);
        int InsertBranch(Branch quotation);
    }

    public interface ICustomerTypeService
    {
        IQueryable<CustomerType> GetAllCustomerTypes();
        CustomerType GetCustomerTypeById(int id);
        int DeleteCustomerType(int id);
        int UpdateCustomerType(CustomerType customerType);
        int InsertCustomerType(CustomerType customerType);
    }

    public interface ICustomerService
    {
        IQueryable<Customer> GetAllCustomers();
        IQueryable<Customer> GetAllActiveCustomers();
        IEnumerable<Customer> GetAllCustomerListBranchWise(int branchid);
        IEnumerable<Customer> GetAllActiveCustomerListBranchWise(int branchid);
        Customer GetCustomerById(int id);        
        int DeleteCustomer(int id);
        int UpdateCustomer(CustomerType customer);
        int InsertCustomer(CustomerType customer);
    }
}

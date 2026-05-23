using FreeBilling.Data.Entities;

namespace FreeBlling.Web.Data
{
    public interface IBillingRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<Employee>> GetEmployees();
        Task<bool> SaveChanges();
    }
}
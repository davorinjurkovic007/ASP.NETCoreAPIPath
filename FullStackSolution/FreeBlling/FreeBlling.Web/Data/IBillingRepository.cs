using FreeBilling.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FreeBlling.Web.Data
{
    public interface IBillingRepository
    {
        Task<IEnumerable<Customer>> GetCustomers();
        Task<IEnumerable<Customer>> GetCustomersWithAddresses();
        Task<Customer?> GetCustomer(int id);

        Task<TimeBill?> GetTimeBill(int id);
        Task<IEnumerable<TimeBill>> GetTimeBillsForCustomer(int id);
        Task<TimeBill?> GetTimeBillsForCustomer(int id, int billId);

        Task<IEnumerable<Employee>> GetEmployees();
        Task<Employee?> GetEmployee(string? name);

        void AddEntity<T>(T entity) where T : notnull;
        Task<bool> SaveChanges();
    }
}
using API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.IRepository
{
    public interface ICustomerRepository
    {
        Task<string> AddCustomer(Customer customer);
        Task<string> UpdateCustomer(Customer customer);
        Task<IEnumerable<Customer>> GetAllData();
        Task<Customer> GetCustomerById(int customerId);
        Task<string> DeleteCustomer(int customerId);
    }
}

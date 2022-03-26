using CLIENT.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CLIENT.IRepository
{
    public interface ICustomerRepository
    {
        Task<HttpResponseMessage> AddCustomer(Customer customer);
        Task<HttpResponseMessage> UpdateCustomer(Customer customer);
        Task<List<Customer>> GetAllData();
        Task<Customer> GetCustomerById(int customerId);
        Task<HttpResponseMessage> DeleteCustomer(int customerId);
    }
}

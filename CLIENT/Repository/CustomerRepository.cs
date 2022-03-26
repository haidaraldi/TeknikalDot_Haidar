using CLIENT.IRepository;
using CLIENT.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CLIENT.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<CustomerRepository> _logger;

        public CustomerRepository(IHttpClientFactory clientFactory, ILogger<CustomerRepository> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<HttpResponseMessage> AddCustomer(Customer customer)
        {
            _logger.LogInformation("Post New Customer");
            var client = _clientFactory.CreateClient("ServiceAPI");
            var response = await client.PostAsJsonAsync("Customer/AddCustomer", customer);

            return response;
        }

        public async Task<HttpResponseMessage> DeleteCustomer(int customerId)
        {
            _logger.LogInformation("Executing DeleteCustomer");
            var client = _clientFactory.CreateClient("ServiceAPI");
            var response = await client.DeleteAsync($"Customer/DeleteCustomer/{customerId}");
            return response;
        }

        public async Task<List<Customer>> GetAllData()
        {
            _logger.LogInformation("Executing GetAllData");
            var client = _clientFactory.CreateClient("ServiceAPI");
            return await client.GetFromJsonAsync<List<Customer>>("Customer/GetAllData");
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            _logger.LogInformation("Executing GetCustomerById");
            var client = _clientFactory.CreateClient("ServiceAPI");
            var response = await client.GetFromJsonAsync<Customer>($"Customer/GetCustomerById/{customerId}");
            return response;
        }

        public async Task<HttpResponseMessage> UpdateCustomer(Customer customer)
        {
            _logger.LogInformation("Executing UpdateCustomer");
            var client = _clientFactory.CreateClient("ServiceAPI");
            var response = await client.PutAsJsonAsync<Customer>($"Customer/UpdateCustomer", customer);
            return response;
        }
    }
}

using CLIENT.IRepository;
using CLIENT.Models;
using CLIENT.ViewModel;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace CLIENT.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<InvoiceRepository> _logger;

        public InvoiceRepository(IHttpClientFactory clientFactory, ILogger<InvoiceRepository> logger)
        {
            _clientFactory = clientFactory;
            _logger = logger;
        }

        public async Task<HttpResponseMessage> AddInvoice(Invoice invoice)
        {
            _logger.LogInformation("Post New Invoice");
            var client = _clientFactory.CreateClient("ServiceAPI");
            var response = await client.PostAsJsonAsync("Invoice/AddInvoice", invoice);

            return response;
        }

        public async Task<HttpResponseMessage> DeleteInvoice(int invoiceId)
        {
            _logger.LogInformation("Executing DeleteInvoice");
            var client = _clientFactory.CreateClient("ServiceAPI");
            var response = await client.DeleteAsync($"Invoice/DeleteInvoice/{invoiceId}");
            return response;
        }

        public async Task<List<Invoice>> GetAllData()
        {
            _logger.LogInformation("Executing GetAllData");
            var client = _clientFactory.CreateClient("ServiceAPI");
            return await client.GetFromJsonAsync<List<Invoice>>("Invoice/GetAllData");
        }

        public async Task<List<CustomerVM>> GetCustomer()
        {
            _logger.LogInformation("Executing GetCustomer");
            var client = _clientFactory.CreateClient("ServiceAPI");
            return await client.GetFromJsonAsync<List<CustomerVM>>("Invoice/GetCustomer");
        }

        public async Task<Invoice> GetInvoiceById(int invoiceId)
        {
            _logger.LogInformation("Executing GetInvoiceById");
            var client = _clientFactory.CreateClient("ServiceAPI");
            var response = await client.GetFromJsonAsync<Invoice>($"Invoice/GetInvoiceById/{invoiceId}");
            return response;
        }

        public async Task<HttpResponseMessage> UpdateInvoice(Invoice invoice)
        {
            _logger.LogInformation("Executing UpdateInvoice");
            var client = _clientFactory.CreateClient("ServiceAPI");
            var response = await client.PutAsJsonAsync<Invoice>($"Invoice/UpdateInvoice", invoice);
            return response;
        }
    }
}

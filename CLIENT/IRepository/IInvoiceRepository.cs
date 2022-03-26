using CLIENT.Models;
using CLIENT.ViewModel;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CLIENT.IRepository
{
    public interface IInvoiceRepository
    {
        Task<HttpResponseMessage> AddInvoice(Invoice invoice);
        Task<HttpResponseMessage> UpdateInvoice(Invoice invoice);
        Task<List<Invoice>> GetAllData();
        Task<Invoice> GetInvoiceById(int invoiceId);
        Task<List<CustomerVM>> GetCustomer();
        Task<HttpResponseMessage> DeleteInvoice(int invoiceId);
    }
}

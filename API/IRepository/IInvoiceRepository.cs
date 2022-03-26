using API.Models;
using API.ViewModel;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.IRepository
{
    public interface IInvoiceRepository
    {
        Task<string> AddInvoice(Invoice invoice);
        Task<string> UpdateInvoice(Invoice invoice);
        Task<IEnumerable<Invoice>> GetAllData();
        Task<Invoice> GetInvoiceById(int invoiceId);
        Task<IEnumerable<CustomerVM>> GetCustomer();
        Task<string> DeleteInvoice(int invoiceId);
    }
}

using API.IRepository;
using API.Models;
using API.ViewModel;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly ApplicationContext _context;

        public InvoiceRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<string> AddInvoice(Invoice invoice)
        {
            try
            {
                if (invoice.Date != null || invoice.CustomerId != 0)
                {
                    var result = await _context.Invoices.AddAsync(invoice);
                    await _context.SaveChangesAsync();

                    return JsonConvert.SerializeObject(invoice);
                }
                else
                {
                    return "Data kosong";
                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<string> DeleteInvoice(int invoiceId)
        {
            try
            {
                var CheckData = await _context.Invoices.Where(x => x.Id == invoiceId).FirstOrDefaultAsync();

                if (CheckData != null)
                {
                    _context.Invoices.Remove(CheckData);
                    await _context.SaveChangesAsync();

                    return "Sukses menghapus data";
                }
                else
                {
                    return "Data tidak ada di database";
                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<IEnumerable<Invoice>> GetAllData()
        {
            var invoices = await _context.Invoices
          .Include(c => c.Customer)
          .ToListAsync();

            return invoices;
        }

        public async Task<IEnumerable<CustomerVM>> GetCustomer()
        {
            var invoices = await _context.Customers.Select(x=> new CustomerVM { CustomerID = x.CustomerId, FullName = string.Join(" ", x.FirstName, x.LastName)})        
              .ToListAsync();

            return invoices;
        }

        public async Task<Invoice> GetInvoiceById(int invoiceId)
        {
            var invoices = await _context.Invoices
              .Include(c => c.Customer).Where(x => x.Id == invoiceId)
              .FirstOrDefaultAsync();

            return invoices;
        }    

        public async Task<string> UpdateInvoice(Invoice invoice)
        {
            try
            {
                var CheckData = await _context.Invoices.Where(x => x.Id == invoice.Id).FirstOrDefaultAsync();

                if (CheckData != null)
                {
                    if (invoice.Date != null || invoice.CustomerId != 0)
                    {
                        CheckData.Date = invoice.Date;
                        CheckData.CustomerId = invoice.CustomerId;

                        await _context.SaveChangesAsync();

                        return JsonConvert.SerializeObject(CheckData, Formatting.None,
                        new JsonSerializerSettings()
                        {
                            ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                        });

                    }
                    else
                    {
                        return "Data kosong";
                    }
                }
                else
                {
                    return "Data tidak ada di database";
                }
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
        }
    }
}

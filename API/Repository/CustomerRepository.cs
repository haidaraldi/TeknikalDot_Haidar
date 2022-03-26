using API.IRepository;
using API.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationContext _context;

        public CustomerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<string> AddCustomer(Customer customer)
        {
            try
            {
                if (customer.FirstName != string.Empty || customer.LastName != string.Empty || customer.Address != string.Empty)
                {
                    var result = await _context.Customers.AddAsync(customer);
                    await _context.SaveChangesAsync();

                    return JsonConvert.SerializeObject(customer);
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

        public async Task<string> DeleteCustomer(int customerId)
        {
            try
            {
                var CheckData = await _context.Customers.Where(x => x.CustomerId == customerId).FirstOrDefaultAsync();

                if (CheckData != null)
                {
                    _context.Customers.Remove(CheckData);
                    await _context.SaveChangesAsync();

                    return "Sukses menghapus data";
                }
                else
                {
                    return "Data tidak ada di database";
                }
            }
            catch(Exception e)
            {
                return e.Message.ToString();
            }
        }

        public async Task<IEnumerable<Customer>> GetAllData()
        {
            var customers = await _context.Customers
            .Include(c => c.Invoices)
            .ToListAsync();

            return customers;
        }

        public async Task<Customer> GetCustomerById(int customerId)
        {
            var customers = await _context.Customers
              .Include(c => c.Invoices).Where(x=> x.CustomerId == customerId)
              .FirstOrDefaultAsync();

            return customers;
        }

        public async Task<string> UpdateCustomer(Customer customer)
        {
            try
            {
                var CheckData = await _context.Customers.Where(x => x.CustomerId == customer.CustomerId).FirstOrDefaultAsync();

                if (CheckData != null)
                {
                    if (customer.FirstName != string.Empty || customer.LastName != string.Empty || customer.Address != string.Empty)
                    {
                        CheckData.CustomerId = customer.CustomerId;
                        CheckData.FirstName = customer.FirstName;
                        CheckData.LastName = customer.LastName;
                        CheckData.Address = customer.Address;

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

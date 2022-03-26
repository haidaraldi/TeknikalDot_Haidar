using API.IRepository;
using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _Customer;

        public CustomerController(ICustomerRepository Customer)
        {
            _Customer = Customer;
        }

        [HttpPost("AddCustomer/")]
        public async Task<ActionResult<string>> AddCustomer(Customer customer)
        {
            return Ok(await _Customer.AddCustomer(customer));
        }

        [HttpGet("GetAllData")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetAllData()
        {
            return Ok(await _Customer.GetAllData());
        }

        [HttpPut("UpdateCustomer/")]
        public async Task<ActionResult<string>> UpdateCustomer(Customer customer)
        {
            return Ok(await _Customer.UpdateCustomer(customer));
        }

        [HttpGet("GetCustomerById/{customerId}")]
        public async Task<ActionResult<Customer>> GetCustomerById(int customerId)
        {
            return Ok(await _Customer.GetCustomerById(customerId));
        }

        [HttpDelete("DeleteCustomer/{customerId}")]
        public async Task<ActionResult<string>> DeleteCustomer(int customerId)
        {
            return Ok(await _Customer.DeleteCustomer(customerId));
        }
    }
}

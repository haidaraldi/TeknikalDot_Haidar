using API.IRepository;
using API.Models;
using API.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceRepository _Invoice;

        public InvoiceController(IInvoiceRepository Invoice)
        {
            _Invoice = Invoice;
        }

        [HttpPost("AddInvoice/")]
        public async Task<ActionResult<string>> AddInvoice(Invoice invoice)
        {
            return Ok(await _Invoice.AddInvoice(invoice));
        }

        [HttpGet("GetAllData")]
        public async Task<ActionResult<IEnumerable<Invoice>>> GetAllData()
        {
            return Ok(await _Invoice.GetAllData());
        }
        
        [HttpGet("GetCustomer")]
        public async Task<ActionResult<IEnumerable<CustomerVM>>> GetCustomer()
        {
            return Ok(await _Invoice.GetCustomer());
        }

        [HttpPut("UpdateInvoice/")]
        public async Task<ActionResult<string>> UpdateInvoice(Invoice invoice)
        {
            return Ok(await _Invoice.UpdateInvoice(invoice));
        }

        [HttpGet("GetInvoiceById/{invoiceId}")]
        public async Task<ActionResult<Invoice>> GetInvoiceById(int invoiceId)
        {
            return Ok(await _Invoice.GetInvoiceById(invoiceId));
        }

        [HttpDelete("DeleteInvoice/{invoiceId}")]
        public async Task<ActionResult<string>> DeleteInvoice(int invoiceId)
        {
            return Ok(await _Invoice.DeleteInvoice(invoiceId));
        }
    }
}

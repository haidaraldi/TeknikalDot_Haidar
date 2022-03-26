using CLIENT.IRepository;
using CLIENT.Models;
using CLIENT.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceController(IInvoiceRepository invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Invoice> invoices = await _invoiceRepository.GetAllData();
            List<CustomerVM> customers = await _invoiceRepository.GetCustomer();

            return View(new MasterDataVM { Invoices = invoices, CustomerVMs = customers });
        }

        [HttpPost]
        public async Task<IActionResult> Index(Invoice invoice)
        {
            var response = await _invoiceRepository.AddInvoice(invoice);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["MessageInput"] = "Success Added Data.";
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Update(int id)
        {
            var response = await _invoiceRepository.GetInvoiceById(id);
            List<Invoice> invoices = await _invoiceRepository.GetAllData();

            return View(new MasterDataVM { Invoices = invoices, Invoice = response});
        }

        [HttpPost]
        public async Task<IActionResult> Update(Invoice invoice)
        {
            var response = await _invoiceRepository.UpdateInvoice(invoice);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["MessageUpdate"] = "Success Updated Data.";
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            var response = await _invoiceRepository.DeleteInvoice(id);

            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                TempData["MessageDelete"] = "Sukses Deleted Data.";
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}

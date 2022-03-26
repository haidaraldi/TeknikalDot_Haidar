using CLIENT.IRepository;
using CLIENT.Models;
using CLIENT.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CLIENT.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _customerRepository;
        public Customer Customer { get; set; }
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IActionResult> Index()
        {
            List<Customer> customers = await _customerRepository.GetAllData();

            return View(new MasterDataVM { Customers = customers });
        }


        [HttpPost]
        public async Task<IActionResult> Index(Customer customer)
        {
            var response = await _customerRepository.AddCustomer(customer);
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
            var response = await _customerRepository.GetCustomerById(id);
            List<Customer> customers = await _customerRepository.GetAllData();
            return View(new MasterDataVM { Customers = customers, Customer = response });
        }

        [HttpPost]
        public async Task<IActionResult> Update(Customer customer)
        {
            var response = await _customerRepository.UpdateCustomer(customer);
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
            var response = await _customerRepository.DeleteCustomer(id);

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

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CLIENT.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "First Name required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name required")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Address required")]
        public string Address { get; set; }
        public virtual List<Invoice> Invoices { get; set; }
    }
}

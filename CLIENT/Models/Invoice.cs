using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CLIENT.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Date required")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Full Name required")]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }
    }
}

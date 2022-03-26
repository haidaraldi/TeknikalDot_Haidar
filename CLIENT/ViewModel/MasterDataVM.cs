using CLIENT.Models;
using System.Collections.Generic;

namespace CLIENT.ViewModel
{
    public class MasterDataVM
    {
        public List<Customer> Customers { get; set; }
        public Customer Customer { get; set; }
    }
}

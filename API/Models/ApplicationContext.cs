using Microsoft.EntityFrameworkCore;

namespace API.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options) { }
        public DbSet<Customer> Customers
        {
            get;
            set;
        }
        public DbSet<Invoice> Invoices
        {
            get;
            set;
        }
    }
}

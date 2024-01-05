using CQRS_Customer_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Customer_CRUD.Context
{
    public class CustomerDbContext : DbContext, ICustomerDbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }
        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DbSet<Customer> Customers { get; set; }
    }
}

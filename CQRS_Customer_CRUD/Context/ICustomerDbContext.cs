using CQRS_Customer_CRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Customer_CRUD.Context
{
    public interface ICustomerDbContext
    {
        DbSet<Customer> Customers { get; set; }

        Task<int> SaveChangesAsync();
    }
}
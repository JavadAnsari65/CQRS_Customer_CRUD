using CQRS_Customer_CRUD.Context;
using CQRS_Customer_CRUD.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Customer_CRUD.CustomerFeatures.Queries.GetCustomerList
{
    public class GetAllCustomersQueryHandler : IRequestHandler<GetAllCustomersQueryModel, IEnumerable<Customer>>
    {
        private readonly ICustomerDbContext _context;
        public GetAllCustomersQueryHandler(ICustomerDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Customer>> Handle(GetAllCustomersQueryModel request, CancellationToken cancellationToken)
        {
            var customerList = await _context.Customers.ToListAsync();
            if (customerList == null)
            {
                return Enumerable.Empty<Customer>();
            }
            return customerList;
        }
    }
}

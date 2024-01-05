using CQRS_Customer_CRUD.Context;
using CQRS_Customer_CRUD.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Customer_CRUD.CustomerFeatures.Queries.FindCustomerById
{
    public class GetCustomerByIdQueryHandler : IRequestHandler<GetCustomerByIdQueryModel, Customer>
    {
        private readonly ICustomerDbContext _context;
        public GetCustomerByIdQueryHandler(ICustomerDbContext context)
        {
            _context = context;
        }

        public async Task<Customer> Handle(GetCustomerByIdQueryModel request, CancellationToken cancellationToken)
        {
            //var customer = _context.Customers.Where(c=>c.Id == request.Id).FirstOrDefault();
            var customer = await _context.Customers.FirstOrDefaultAsync(c=> c.Id == request.Id);
            if (customer == null)
            {
                return null;
            }
            return customer;
        }
    }
}

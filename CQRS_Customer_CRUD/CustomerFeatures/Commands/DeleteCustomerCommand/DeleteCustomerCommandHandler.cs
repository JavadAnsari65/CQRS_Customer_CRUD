using CQRS_Customer_CRUD.Context;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_Customer_CRUD.CustomerFeatures.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommandHandler : IRequestHandler<DeleteCustomerCommandModel, Guid>
    {
        private readonly ICustomerDbContext _context;
        public DeleteCustomerCommandHandler(ICustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(DeleteCustomerCommandModel request, CancellationToken cancellationToken)
        {
            var customer = await _context.Customers.Where(c => c.Id == request.Id).FirstOrDefaultAsync();
            if (customer == null) return default;
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }
    }
}

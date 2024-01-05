using CQRS_Customer_CRUD.Context;
using MediatR;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace CQRS_Customer_CRUD.CustomerFeatures.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommandModel, Guid>
    {
        //private readonly ICustomerDbContext _context;
        private readonly ICustomerDbContext _context;
        public UpdateCustomerCommandHandler(ICustomerDbContext context)
        {
            _context = context;            
        }

        public async Task<Guid> Handle(UpdateCustomerCommandModel request, CancellationToken cancellationToken)
        {
            var customer = _context.Customers.Where(a => a.Id == request.Id).FirstOrDefault();
            if (customer == null)
            {
                return default;
            }
            else
            {
                customer.Name = request.Name;
                customer.Family = request.Family;
                customer.NationalCode = request.NationalCode;
                customer.MobileNumber = request.MobileNumber;
                customer.Email = request.Email;
                _context.Customers.Update(customer);
                await _context.SaveChangesAsync();
                return customer.Id;
            }
        }
    }
}

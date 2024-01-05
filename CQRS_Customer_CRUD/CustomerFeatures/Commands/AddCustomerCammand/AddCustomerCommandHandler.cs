using CQRS_Customer_CRUD.Context;
using CQRS_Customer_CRUD.Models;
using MediatR;
using System;

namespace CQRS_Customer_CRUD.CustomerFeatures.Commands.AddCustomerCammand
{
    public class AddCustomerCommandHandler : IRequestHandler<AddCustomerCommandModel, Guid>
    {
        private readonly ICustomerDbContext _context;
        public AddCustomerCommandHandler(ICustomerDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(AddCustomerCommandModel request, CancellationToken cancellationToken)
        {
            var customer = new Customer
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                Email = request.Email,
                Family = request.Family,
                MobileNumber = request.MobileNumber,
                NationalCode = request.NationalCode,
                Password = request.Password
            };
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer.Id;
        }
    }
}

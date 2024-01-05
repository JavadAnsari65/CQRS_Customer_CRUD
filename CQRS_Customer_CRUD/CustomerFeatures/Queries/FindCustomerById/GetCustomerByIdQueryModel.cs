using CQRS_Customer_CRUD.Models;
using MediatR;

namespace CQRS_Customer_CRUD.CustomerFeatures.Queries.FindCustomerById
{
    public class GetCustomerByIdQueryModel : IRequest<Customer>
    {
        public Guid Id { get; set; }
    }
}

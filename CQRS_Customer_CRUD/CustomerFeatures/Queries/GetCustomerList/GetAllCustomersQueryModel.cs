using CQRS_Customer_CRUD.Models;
using MediatR;

namespace CQRS_Customer_CRUD.CustomerFeatures.Queries.GetCustomerList
{
    public class GetAllCustomersQueryModel : IRequest<IEnumerable<Customer>>
    {
    
    }
}

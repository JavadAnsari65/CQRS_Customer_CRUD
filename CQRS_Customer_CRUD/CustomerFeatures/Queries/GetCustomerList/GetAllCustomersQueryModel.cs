using CQRS_Customer_CRUD.Models;
using MediatR;

namespace CQRS_Customer_CRUD.CustomerFeatures.Queries.GetCustomerList
{
    public class GetAllCustomersQueryModel : IRequest<IEnumerable<Customer>>
    {
        /*
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        */
        
    }
}

using MediatR;

namespace CQRS_Customer_CRUD.CustomerFeatures.Commands.UpdateCustomerCommand
{
    public class UpdateCustomerCommandModel : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
    }
}

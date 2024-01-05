using MediatR;

namespace CQRS_Customer_CRUD.CustomerFeatures.Commands.DeleteCustomerCommand
{
    public class DeleteCustomerCommandModel : IRequest<Guid>
    {
        public Guid Id { get; set; }
    }
}

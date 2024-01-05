using MediatR;

namespace CQRS_Customer_CRUD.CustomerFeatures.Commands.AddCustomerCammand
{
    public class AddCustomerCommandModel : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RepeatPassword { get; set; }
    }
}

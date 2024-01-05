using CQRS_Customer_CRUD.Context;
using CQRS_Customer_CRUD.CustomerFeatures.Commands.AddCustomerCammand;
using CQRS_Customer_CRUD.CustomerFeatures.Commands.DeleteCustomerCommand;
using CQRS_Customer_CRUD.CustomerFeatures.Commands.UpdateCustomerCommand;
using CQRS_Customer_CRUD.CustomerFeatures.Queries.FindCustomerById;
using CQRS_Customer_CRUD.CustomerFeatures.Queries.GetCustomerList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Customer_CRUD.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer(AddCustomerCommandModel command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _mediator.Send(new GetAllCustomersQueryModel()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            return Ok(await _mediator.Send(new GetCustomerByIdQueryModel { Id = id }));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return Ok(await _mediator.Send(new DeleteCustomerCommandModel { Id = id }));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateCustomerCommandModel command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }
    }
}

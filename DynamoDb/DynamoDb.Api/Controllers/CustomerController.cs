using DynamoDb.Api.Application.UseCases.CreateCustomer;
using DynamoDb.Api.Application.UseCases.DeleteCustomer;
using DynamoDb.Api.Application.UseCases.GetAllCustomers;
using DynamoDb.Api.Application.UseCases.GetCustomer;
using DynamoDb.Api.Application.UseCases.UpdateCustomer;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DynamoDb.Api.Controllers;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ISender _mediator;

    public CustomerController(ILogger<CustomerController> logger, IMediator mediator)
    {
        _logger = logger;
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCustomers()
    {
        try
        {
            var response = await _mediator.Send(new GetAllCustomersQuery());
            return Ok(response);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An exception occurred while getting all customers");
            return Problem(title: "InternalError", detail: e.Message);
        }
    }
    
    [HttpGet("{id}", Name = "GetCustomerById")]
    public async Task<IActionResult> GetCustomerById([FromRoute] Guid id)
    {
        try
        {
            var response = await _mediator.Send(new GetCustomerQuery(id));
            return response is not null
                ? Ok(response)
                : NotFound(new{ Message = "Customer not found"});
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An exception occurred while getting customer");
            return Problem(title: "InternalError", detail: e.Message);
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetCustomerById), new { response.Id }, response);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An exception occurred while creating customer");
            return Problem(title: "InternalError", detail: e.Message);
        }
    }
    
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerCommand command)
    {
        try
        {
            var response = await _mediator.Send(command);

            if (response is null)
                return NotFound(new {Message = "Customer not found"});
            
            return NoContent();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An exception occurred while updating customer");
            return Problem(title: "InternalError", detail: e.Message);
        }
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCustomer([FromRoute] Guid id)
    {
        try
        {
            var response = await _mediator.Send(new DeleteCustomerCommand(id));
            
            if (response == null)
                return NotFound(new {Message = "Customer not found"});
            
            return NoContent();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An exception occurred while deleting customer");
            return Problem(title: "InternalError", detail: e.Message);
        }
    }
}
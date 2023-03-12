using Microsoft.AspNetCore.Mvc;
using SNSPublisher.Models;
using SNSPublisher.Services;
using SNSPublisher.Shared.Constants;

namespace SNSPublisher.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ISnsService _snsService;

    public CustomerController(ILogger<CustomerController> logger, ISnsService snsService)
    {
        _logger = logger;
        _snsService = snsService;
    }

    [HttpPost(Name = "CreateCustomer")]
    public async Task<IActionResult> CreateCustomer(CreateCustomerRequest createCustomerRequest)
    {
        try
        {
            await _snsService.PublishMessageAsync(createCustomerRequest, Topics.CreateCustomer);
        
            _logger.LogInformation("Message successfully published to customers topic");
            
            return Accepted();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An exception occured at {CustomerController}", nameof(CustomerController));
            return Problem(statusCode: 500, title: e.Message, detail: e.StackTrace);
        }
    }
}
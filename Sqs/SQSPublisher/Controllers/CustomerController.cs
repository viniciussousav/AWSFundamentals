using Microsoft.AspNetCore.Mvc;
using SQSPublisher.Models;
using SQSPublisher.Services;
using SQSPublisher.Shared.Constants;

namespace SQSPublisher.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly ILogger<CustomerController> _logger;
    private readonly ISqsService _sqsService;

    public CustomerController(ILogger<CustomerController> logger, ISqsService sqsService)
    {
        _logger = logger;
        _sqsService = sqsService;
    }

    [HttpPost(Name = "CreateCustomer")]
    public async Task<IActionResult> CreateCustomer(CreateCustomerRequest createCustomerRequest)
    {
        try
        {
            await _sqsService.SendMessageAsync(createCustomerRequest, Queues.CreateCustomerQueue);
        
            _logger.LogInformation("Message successfully published to customer queue");
            
            return Accepted();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An exception occured at {CustomerController}", nameof(CustomerController));
            return Problem(statusCode: 500, title: e.Message, detail: e.StackTrace);
        }
    }
}
using System.Net;
using Amazon.S3;
using AmazonS3Example.API.Infrastructure.Services.S3;
using Microsoft.AspNetCore.Mvc;

namespace AmazonS3Example.API.Controllers;

[ApiController]
[Route("images")]
public class ImageController : ControllerBase
{
    private readonly ILogger<ImageController> _logger;
    private readonly IImageService _imageService;

    public ImageController(ILogger<ImageController> logger, IImageService imageService)
    {
        _logger = logger;
        _imageService = imageService;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        try
        {
            var response = await _imageService.GetImage(id);
            return File(response.ResponseStream, "image/png");
        }
        catch (AmazonS3Exception e) when (e.StatusCode == HttpStatusCode.NotFound)
        {
            _logger.LogError(e, "The object with Id {Id} was not found", id);
            return Problem(statusCode: 400, title: "Not found", detail: e.Message);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An unexpected exception occurred");
            return Problem(statusCode: 500, title: "Internal server error", detail: e.Message);
        }
    }
    
    [HttpPost("{id:guid}")]
    public async Task<IActionResult> Upload(Guid id, [FromForm(Name = "Data")] IFormFile file)
    {
        try
        {
            var response = await _imageService.UploadImage(id, file);

            if (response.HttpStatusCode != HttpStatusCode.OK)
                return BadRequest();

            return Ok();
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An unexpected exception occurred");
            return Problem(statusCode: 500, title: "Internal server error", detail: e.Message);
        }
    }
    
    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var response = await _imageService.DeleteImage(id);

            return response.HttpStatusCode switch
            {
                HttpStatusCode.NoContent => Ok(),
                HttpStatusCode.NotFound => NotFound(),
                _ => BadRequest()
            };
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An unexpected exception occurred");
            return Problem(statusCode: 500, title: "Internal server error", detail: e.Message);
        }
    }
}
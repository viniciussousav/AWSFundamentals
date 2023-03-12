using System.Text.Json.Serialization;

namespace DynamoDb.Api.Infrastructure.Persistence.Repositories;

public class CustomerDto
{
    [JsonPropertyName("pk")] 
    public string Pk => Id.ToString();

    [JsonPropertyName("sk")] 
    public string Sk => Id.ToString();
    
    public Guid Id { get; init; }
    
    public string FullName { get; init; }
    
    public string GitHubUsername { get; init; }
    
    public string Email { get; init; }
    
    public DateTime DateOfBirth { get; init; }
    
    public DateTime UpdatedAt { get; set; }
}
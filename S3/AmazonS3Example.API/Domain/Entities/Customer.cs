namespace AmazonS3Example.API.Domain.Entities;

public class Customer
{
    public Customer(Guid id, string fullName, string email, string gitHubUsername, DateTime dateOfBirth)
    {
        Id = id;
        FullName = fullName;
        Email = email;
        GitHubUsername = gitHubUsername;
        DateOfBirth = dateOfBirth;
    }
    
    public Guid Id { get; }
    public string FullName { get; }
    public string Email { get; }
    public string GitHubUsername { get; }
    public DateTime DateOfBirth { get; }
}
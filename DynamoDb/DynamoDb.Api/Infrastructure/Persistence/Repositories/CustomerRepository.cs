using System.Globalization;
using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using DynamoDb.Api.Domain.Repositories;

namespace DynamoDb.Api.Infrastructure.Persistence.Repositories;

public class CustomerRepository : ICustomerRepository
{
    private readonly IAmazonDynamoDB _dynamoDb;
    private const string TableName = "customers";

    public CustomerRepository(IAmazonDynamoDB dynamoDb)
    {
        _dynamoDb = dynamoDb;
    }

    public async Task<bool> CreateAsync(CustomerDto customer)
    {
        customer.UpdatedAt = DateTime.Now;
        var customerAsJson = JsonSerializer.Serialize(customer);
        var customerAsAttributes = Document.FromJson(customerAsJson).ToAttributeMap();

        var createItemRequest = new PutItemRequest
        {
            TableName = TableName,
            Item = customerAsAttributes
        };

        var response = await _dynamoDb.PutItemAsync(createItemRequest);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    public async Task<CustomerDto?> GetAsync(Guid id)
    {
        var getItemRequest = new GetItemRequest
        {
            TableName = TableName,
            Key = new Dictionary<string, AttributeValue>
            {
                {"pk", new () {S = id.ToString()}},
                {"sk", new () {S = id.ToString()}}
            }
        };

        var response = await _dynamoDb.GetItemAsync(getItemRequest);

        if (!response.Item.Any())
            return null;
        
        var itemAsDocument = Document.FromAttributeMap(response.Item);
        return JsonSerializer.Deserialize<CustomerDto>(itemAsDocument.ToJson());
    }

    public async Task<IEnumerable<CustomerDto>> GetAllAsync()
    {
        var scanRequest = new ScanRequest
        {
            TableName = TableName
        };

        var response = await _dynamoDb.ScanAsync(scanRequest);

        return response.Items.Select(x =>
        {
            var json = Document.FromAttributeMap(x).ToJson();
            return JsonSerializer.Deserialize<CustomerDto>(json);
        })!;
    }

    public async Task<bool> UpdateAsync(CustomerDto customer)
    {
        customer.UpdatedAt = DateTime.Now;
        var customerAsJson = JsonSerializer.Serialize(customer);
        var customerAsAttributes = Document.FromJson(customerAsJson).ToAttributeMap();

        var updateItemRequest = new PutItemRequest
        {
            TableName = TableName,
            Item = customerAsAttributes,
            ConditionExpression = "UpdatedAt < :requestStarted",
            ExpressionAttributeValues = new Dictionary<string, AttributeValue>
            {
                {":requestStarted", new AttributeValue { S = customer.UpdatedAt.ToString("O")}}
            }
        };

        var response = await _dynamoDb.PutItemAsync(updateItemRequest);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var deleteItemRequest = new DeleteItemRequest()
        {
            TableName = TableName,
            Key = new Dictionary<string, AttributeValue>
            {
                {"pk", new() {S = id.ToString()}},
                {"sk", new() {S = id.ToString()}}
            }
        };

        var response = await _dynamoDb.DeleteItemAsync(deleteItemRequest);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }
}
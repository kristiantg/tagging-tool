using System.Net;
using System.Text.Json;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Application.Contracts.Data;
using Application.Settings;
using Microsoft.Extensions.Options;

namespace Infrastructure.Repositories;

public class TagRepository : ITagRepository
{
    private readonly IAmazonDynamoDB _dynamoDb;
    private readonly IOptions<DatabaseSettings> _databaseSettings;

    public TagRepository(IAmazonDynamoDB dynamoDb,
        IOptions<DatabaseSettings> databaseSettings)
    {
        _dynamoDb = dynamoDb;
        _databaseSettings = databaseSettings;
    }
    public async Task<bool> CreateAsync(TagDto tag)
    {
        var tagAsJson = JsonSerializer.Serialize(tag);
        var itemAsDocument = Document.FromJson(tagAsJson);
        var itemAsAttributes = itemAsDocument.ToAttributeMap();

        var createItemRequest = new PutItemRequest
        {
            TableName = _databaseSettings.Value.TableName,
            Item = itemAsAttributes
        };

        var response = await _dynamoDb.PutItemAsync(createItemRequest);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    public async Task<TagDto?> GetAsync(Guid id)
    {
        var request = new GetItemRequest
        {
            TableName = _databaseSettings.Value.TableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "pk", new AttributeValue { S = id.ToString() } },
                { "sk", new AttributeValue { S = id.ToString() } }
            }
        };

        var response = await _dynamoDb.GetItemAsync(request);
        if (response.Item.Count == 0)
        {
            return null;
        }

        var itemAsDocument = Document.FromAttributeMap(response.Item);
        return JsonSerializer.Deserialize<TagDto>(itemAsDocument.ToJson());
    }

    public async Task<IEnumerable<TagDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<bool> UpdateAsync(TagDto tag)
    {
        var tagAsJson = JsonSerializer.Serialize(tag);
        var itemAsDocument = Document.FromJson(tagAsJson);
        var itemAsAttributes = itemAsDocument.ToAttributeMap();

        var updateItemRequest = new PutItemRequest
        {
            TableName = _databaseSettings.Value.TableName,
            Item = itemAsAttributes
        };

        var response = await _dynamoDb.PutItemAsync(updateItemRequest);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var deleteItemRequest = new DeleteItemRequest
        {
            TableName = _databaseSettings.Value.TableName,
            Key = new Dictionary<string, AttributeValue>
            {
                { "pk", new AttributeValue { S = id.ToString() } },
                { "sk", new AttributeValue { S = id.ToString() } }
            }
        };

        var response = await _dynamoDb.DeleteItemAsync(deleteItemRequest);
        return response.HttpStatusCode == HttpStatusCode.OK;
    }
}
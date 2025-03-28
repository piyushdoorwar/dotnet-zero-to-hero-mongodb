using Mongo.Service.Model;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo.Service;

public class ProductService
{
    private readonly IMongoCollection<Product> _products;

    public ProductService(IOptions<MongoDbSettings> options, IMongoClient client)
    {
        var mongoSettings = options.Value;
        var database = client.GetDatabase(mongoSettings.DatabaseName);
        _products = database.GetCollection<Product>("Products");
    }

    public async Task<List<Product>> GetAllAsync() =>
        await _products.Find(_ => true).ToListAsync();

    public async Task<Product?> GetByIdAsync(string id) =>
        await _products.Find(p => p.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Product product) =>
        await _products.InsertOneAsync(product);

    public async Task UpdateAsync(string id, Product product) =>
        await _products.ReplaceOneAsync(p => p.Id == id, product);

    public async Task DeleteAsync(string id) =>
        await _products.DeleteOneAsync(p => p.Id == id);
}

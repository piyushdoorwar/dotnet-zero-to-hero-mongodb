using HotChocolate.Data;
using Mongo.Service.Model;
using Mongo.Service;
using MongoDB.Driver;

namespace GraphQl.Api;

public class Query
{
    public IEnumerable<Product> GetProducts(
        [Service] MongoDbContext context,
        int page = 1,
        int pageSize = 10)
    {
        return [.. context.Products
            .AsQueryable()
            .Skip((page - 1) * pageSize)
            .Take(pageSize)];
    }
}


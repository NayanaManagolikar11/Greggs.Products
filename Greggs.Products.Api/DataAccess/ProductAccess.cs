using System.Collections.Generic;
using System.Linq;
using Greggs.Products.Api.Models;
using Greggs.Products.Api.Services;

namespace Greggs.Products.Api.DataAccess;

/// <summary>
/// DISCLAIMER: This is only here to help enable the purpose of this exercise, this doesn't reflect the way we work!
/// </summary>
public class ProductAccess : IDataAccess<Product>
{
    private static readonly IEnumerable<Product> ProductDatabase = new List<Product>()
    {
        new() { Name = "Sausage Roll", Price = 1m },
        new() { Name = "Vegan Sausage Roll", Price = 1.1m },
        new() { Name = "Steak Bake", Price = 1.2m },
        new() { Name = "Yum Yum", Price = 0.7m },
        new() { Name = "Pink Jammie", Price = 0.5m },
        new() { Name = "Mexican Baguette", Price     = 2.1m },
        new() { Name = "Bacon Sandwich", Price = 1.95m },
        new() { Name = "Coca Cola", Price = 1.2m }
    };
    private IPriceConverter _priceConverter;

    public ProductAccess(IPriceConverter priceConverter)
    {
        _priceConverter = priceConverter;
    }

    public IEnumerable<Product> List(string currencyType, int? pageStart, int? pageSize)
    {
        var products = ProductDatabase.AsQueryable();

        if (pageStart.HasValue)
            products = products.Skip(pageStart.Value);

        if (pageSize.HasValue)
            products = products.Take(pageSize.Value);
        IPriceConverter converter = PriceConverterFactory.GetPriceConverterInstance(currencyType);
        foreach (var product in products)
        {
            product.Price = converter.ConvertPrice(product.Price);
        };

        return products.ToList();


    }
}
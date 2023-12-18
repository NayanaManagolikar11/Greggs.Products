﻿using System;
using System.Collections.Generic;
using System.Linq;
using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Greggs.Products.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    //private static readonly string[] Products = new[]
    //{
    //    "Sausage Roll", "Vegan Sausage Roll", "Steak Bake", "Yum Yum", "Pink Jammie"
    //};

    private readonly ILogger<ProductController> _logger;
    private IDataAccess<Object> _dataAccess;
    public ProductController(ILogger<ProductController> logger, IDataAccess<Object> dataAccess)
    {
        _logger = logger;
        _dataAccess = dataAccess;
    }

    [HttpGet]
    public IEnumerable<Product> Get(string currencyType = "GBP", int pageStart = 0, int pageSize = 5)
    {
        return (List<Product>)_dataAccess.List(currencyType, pageStart, pageSize);
    }
}
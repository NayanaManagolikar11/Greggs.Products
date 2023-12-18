using Greggs.Products.Api.Controllers;
using Greggs.Products.Api.DataAccess;
using Greggs.Products.Api.Models;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Greggs.Products.UnitTests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Get_All_Products_Success()
        {
            //Arrange
            int pageStart = 0;
            int pageSize = 8;
            string currencyType = "Euro";
            var _dataAccess = new Mock<IDataAccess<Object>>();
            var _logger = new Mock<ILogger<ProductController>>();
            _dataAccess.Setup(p => p.List(currencyType, pageStart, pageSize)).Returns(GetProducts).Verifiable();
            var controller = new ProductController(_logger.Object, _dataAccess.Object);
            //Act
            var result = controller.Get(currencyType, pageStart, pageSize).ToList();
            //Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);

        }
        private List<Product> GetProducts()
        {
            var products = new List<Product>()
            {
                 new() { Name = "Donut", Price = 1m },
                 new() { Name = "Pizza", Price = 1.1m },
                 new() { Name = "Potato Wedges", Price = 1.2m }

            };
            return products;

        }
    }
}

using Greggs.Products.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Greggs.Products.UnitTests
{
    public class PriceConverterFatoryTest
    {
        [Fact]
        public void GetPriceConverterInstance_IS_NOT_NULL()
        {
            //Arrange
            string currency = "EUR";
            //Act
            var priceConverterInstance = PriceConverterFactory.GetPriceConverterInstance(currency);
            //Assert
            Assert.NotNull(priceConverterInstance);
        }
    }
}

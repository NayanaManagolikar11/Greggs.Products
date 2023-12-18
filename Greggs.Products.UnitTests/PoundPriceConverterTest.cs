using Greggs.Products.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Greggs.Products.UnitTests
{
    public class PoundPriceConverterTest
    {
        [Theory]
        [InlineData(3.1)]
        [InlineData(1.5)]
        [InlineData(2)]
        public void PoundConverterSuccess(decimal priceToConvert)
        {
            //Arrange

            PoundPriceConverter priceConverter = new PoundPriceConverter();
            const Decimal exchangeRate = 1;
            //Act
            var convertedPrice = priceConverter.ConvertPrice(priceToConvert);
            priceToConvert = Math.Round((Decimal.Multiply(priceToConvert, exchangeRate)), 2);

            //Assert

            Assert.Equal(priceToConvert, convertedPrice);

        }

    }
}

using Greggs.Products.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Greggs.Products.UnitTests
{
    public class EuroPriceConverterTest
    {
        [Theory]
        [InlineData(3.1)]
        [InlineData(1.5)]
        [InlineData(2)]
        public void EuroConverterSuccess(decimal priceToConvert)
        {
            //Arrange

            EuroPriceConverter priceConverter = new EuroPriceConverter();
            const Decimal exchangeRate = 1.11m;
            //Act
            var convertedPrice = priceConverter.ConvertPrice(priceToConvert);
            priceToConvert = Math.Round((Decimal.Multiply(priceToConvert, exchangeRate)), 2);

            //Assert

            Assert.Equal(priceToConvert, convertedPrice);

        }

    }
}

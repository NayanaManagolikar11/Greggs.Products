using System;

namespace Greggs.Products.Api.Services
{
    public class PoundPriceConverter:IPriceConverter
    {
        const Decimal exchangeRate = 1;
        public Decimal ConvertPrice(Decimal price)
        {

            return Math.Round((Decimal.Multiply(price, exchangeRate)), 2);

        }
    }
}

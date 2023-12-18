using System;

namespace Greggs.Products.Api.Services
{
    public class EuroPriceConverter:IPriceConverter
    {
        const Decimal exchangeRate = 1.11m;
        public Decimal ConvertPrice(Decimal price)
        {

            return Math.Round((Decimal.Multiply(price, exchangeRate)), 2);

        }
    }
}

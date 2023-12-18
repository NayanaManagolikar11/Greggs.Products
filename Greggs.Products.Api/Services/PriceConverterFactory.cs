namespace Greggs.Products.Api.Services
{
    public class PriceConverterFactory
    {
        public static IPriceConverter GetPriceConverterInstance(string CurrencyType)
        {
            switch (CurrencyType)
            {
                case "GBP": return new PoundPriceConverter();
                case "EUR": return new EuroPriceConverter();
                default: return null;
            }
        }
    }
}

using System;

namespace Greggs.Products.Api.Services
{
    public interface IPriceConverter
    {
        public Decimal ConvertPrice(decimal price);
    }
}

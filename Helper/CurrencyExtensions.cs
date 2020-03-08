
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Helpers
{
    public static class CurrencyExtensions
    {
        public static decimal Convert(decimal ratio, decimal originalAmount)
        {
            return originalAmount * ratio;
        }
    }
}

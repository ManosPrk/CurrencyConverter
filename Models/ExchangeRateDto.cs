using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Models
{
    public class ExchangeRateDto
    {
        public Guid ExchangeRateId { get; set; }
        public Guid FromCurrencyId { get; set; }
        public Guid ToCurrencyId { get; set; }
        public decimal Ratio { get; set; }
    }
}

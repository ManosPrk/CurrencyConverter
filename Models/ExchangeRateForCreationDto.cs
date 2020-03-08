using CurrencyConverter.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Models
{
    public class ExchangeRateForCreationDto
    {
        public Guid? FromCurrencyId { get; set; }
        public Guid? ToCurrencyId { get; set; }
        public decimal Ratio { get; set; }
    }
}

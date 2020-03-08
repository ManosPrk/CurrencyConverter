using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Models
{
    public class ConversionDto
    {
        public Guid? FromCurrencyId { get; set; }
        public Guid? ToCurrencyId { get; set; }

        public decimal Amount { get; set; }
    }
}

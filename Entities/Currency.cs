using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Entities
{
    public class Currency
    {
        [Key]
        public Guid CurrencyId { get; set; }
        public string IsoCode { get; set; }
        public string FullName { get; set; }

        [InverseProperty("FromCurrency")]
        public ICollection<ExchangeRate> FromRates { get; set; } = new List<ExchangeRate>();
        [InverseProperty("ToCurrency")]
        public ICollection<ExchangeRate> ToRates { get; set; } = new List<ExchangeRate>();
    }
}

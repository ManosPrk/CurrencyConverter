using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Entities
{
    public class ExchangeRate
    {
        [Key]
        public Guid ExchangeRateId { get; set; }

        [ForeignKey("FromCurrency")]
        public Guid? FromCurrencyId { get; set; }
        public Currency FromCurrency { get; set; }

        
        [ForeignKey("ToCurrency")]
        public Guid? ToCurrencyId { get; set; }
        public Currency ToCurrency { get; set; }

        [Column(TypeName = "decimal(18,4)")]
        public decimal Ratio { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Entities
{
    public class FromCurrencyRelation
    {
        public Guid FromCurrencyRelationId { get; set; }
        public Guid FromCurrencyId { get; set; }
        [ForeignKey("FromCurrencyId")]
        public FromCurrency FromCurrency { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Entities
{
    public class ToCurrencyRelation
    {
        [Key]
        public Guid ToCurrencyRelationId { get; set; }
        public Guid ToCurrencyId { get; set; }
        [ForeignKey("ToCurrencyId")]
        public ToCurrency ToCurrency { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Entities
{
    public class FromCurrency
    {
        [Key]
        public Guid FromCurrencyId { get; set; }
        [ForeignKey("FromRelationId")]
        public FromRelation FromRelation { get; set; }
        public Guid FromRelationId { get; set; }
        public string IsoCode { get; set; }
        public string FullName { get; set; }
    }
}

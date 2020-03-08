using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Entities
{
    public class ToCurrency
    {
        [Key]
        public Guid ToCurrencyId { get; set; }

        [ForeignKey("ToRelationId")]
        public ToRelation ToRelation { get; set; }
        public Guid ToRelationId { get; set; }
        public string IsoCode { get; set; }
        public string FullName { get; set; }
    }
}

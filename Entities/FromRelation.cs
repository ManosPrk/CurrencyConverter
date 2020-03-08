using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Entities
{
    public class FromRelation
    {
        [Key]
        public Guid CurrencyRelationId { get; set; }
        public Guid CurrencyId { get; set; }
        [ForeignKey("CurrencyId")]
        public Currency Currency { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Models
{
    public class CurrencyDto
    {
        public Guid CurrencyId { get; set; }
        public string IsoCode { get; set; }
        public string FullName { get; set; }

    }
}

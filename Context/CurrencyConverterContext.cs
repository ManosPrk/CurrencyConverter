using CurrencyConverter.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Context
{
    public class CurrencyConverterContext: DbContext
    {
        public CurrencyConverterContext(DbContextOptions<CurrencyConverterContext> options)
        : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Currency> Currencies { get; set; }
        public DbSet<FromRelation> FromRelations { get; set; }
        public DbSet <ToRelation> ToRelations { get; set; }
        public DbSet<FromCurrency> FromCurrencies { get; set; }
        public DbSet<ToCurrency> ToCurrencies { get; set; }
        public DbSet<ExchangeRate> ExchangeRates { get; set; }


    }
}

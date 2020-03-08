
using CurrencyConverter.API.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Services
{
    public interface ICurrencyConverterRepo
    {
        void AddCurrency(Currency currency);
        FromRelation AddFromRelation(Currency currency);
        void AddToCurrency(ToRelation relation);
        void Save();
        Currency GetCurrency(Guid currencyId);
        void AddFromCurrency(FromRelation relation);
        ToRelation AddToRelation(Currency currency);
        IEnumerable<Currency> GetCurrencies(string searchQuery);
        FromCurrency GetFromCurrency(Guid? fromId);
        ToCurrency GetToCurrency(Guid? toId);
        void AddRate(ExchangeRate exchangeRate, bool createReverse = false);
        IEnumerable<ExchangeRate> GetRates(Guid currencyId);
        bool CurrencyExists(Guid? currencyId);
        ExchangeRate GetRate(Guid? fromCurrencyId, Guid? toCurrencyId);
        void DeleteExchangeRate(ExchangeRate rate);
        void DeleteCurrency(Currency currency);
        ExchangeRate GetReverseRate(ExchangeRate exchangeRateEntity);
        bool RateExists(Guid? RateId);
        ExchangeRate GetRate(Guid rateId);
    }
}

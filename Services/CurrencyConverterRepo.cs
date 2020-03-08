
using CurrencyConverter.API.Context;
using CurrencyConverter.API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Services
{
    public class CurrencyConverterRepo : ICurrencyConverterRepo
    {
        private readonly CurrencyConverterContext _context;

        public CurrencyConverterRepo(CurrencyConverterContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public Currency GetCurrency(Guid currencyId)
        {
            if (currencyId == null)
            {
                throw new ArgumentNullException();
            }
            return _context.Currencies
                            .Where(c => c.CurrencyId == currencyId)
                            .FirstOrDefault();
        }

        public void AddCurrency(Currency currency)
        {
            _context.Currencies.Add(currency);
        }

        public bool CurrencyExists(Guid? currencyId)
        {
            return _context.Currencies.Any(c => c.CurrencyId == currencyId);
        }

        public FromRelation AddFromRelation(Currency currency)
        {
            var relation = new FromRelation()
            {
                CurrencyId = currency.CurrencyId
            };
            _context.FromRelations.Add(relation);
            return relation;
        }

        public ToRelation AddToRelation(Currency currency)
        {
            var relation = new ToRelation()
            {
                CurrencyId = currency.CurrencyId
            };
            _context.ToRelations.Add(relation);
            return relation;
        }

        public void AddFromCurrency(FromRelation relation)
        {
            var currency = _context.Currencies.Where(c => c.CurrencyId == relation.CurrencyId).FirstOrDefault();
            var fromCur = new FromCurrency()
            {
                FromCurrencyId = relation.CurrencyId,
                FromRelation = relation,
                FromRelationId = relation.CurrencyRelationId,
                FullName = currency.FullName,
                IsoCode = currency.IsoCode
            };
            _context.FromCurrencies.Add(fromCur);
        }

        public FromCurrency GetFromCurrency(Guid? fromId)
        {
            return _context.FromCurrencies.Where(fc => fc.FromCurrencyId == fromId).FirstOrDefault();
        }
        public ToCurrency GetToCurrency(Guid? toId)
        {
            return _context.ToCurrencies.Where(fc => fc.ToCurrencyId == toId).FirstOrDefault();
        }

        public void AddToCurrency(ToRelation relation)
        {
            var currency = _context.Currencies.Where(c => c.CurrencyId == relation.CurrencyId).FirstOrDefault();
            var targetCur = new ToCurrency()
            {
                ToCurrencyId = relation.CurrencyId,
                ToRelation = relation,
                ToRelationId = relation.CurrencyRelationId,
                FullName = currency.FullName,
                IsoCode = currency.IsoCode
            };
            _context.ToCurrencies.Add(targetCur);
        }


        public void AddRate(ExchangeRate exchangeRate, bool createReverse = false)
        {
            _context.ExchangeRates.Add(exchangeRate);
            if (createReverse)
            {
                _context.ExchangeRates.Add(new ExchangeRate()
                {
                    ExchangeRateId = Guid.NewGuid(),
                    FromCurrencyId = exchangeRate.ToCurrencyId,
                    ToCurrencyId = exchangeRate.FromCurrencyId,
                    Ratio = Math.Round(1 / exchangeRate.Ratio, 4),

                });
            }
        }

        public IEnumerable<ExchangeRate> GetRates(Guid currencyId)
        {
            return _context.ExchangeRates.Where(r => r.FromCurrencyId == currencyId || r.ToCurrencyId == currencyId);
        }

        public ExchangeRate GetRate(Guid? fromCurrencyId, Guid? toCurrencyId)
        {
            return _context.ExchangeRates.Where(r => r.FromCurrencyId == fromCurrencyId && r.ToCurrencyId == toCurrencyId)
                                         .FirstOrDefault();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public IEnumerable<Currency> GetCurrencies(string searchQuery)
        {
            if (searchQuery != null)
            {
                return _context.Currencies.Where(c => c.IsoCode.Contains(searchQuery)).ToList();
            }
            return _context.Currencies.ToList();
        }

        public void AddRateToCurrency(ExchangeRate exchangeRateEntity)
        {
            var fromCurId = exchangeRateEntity.FromCurrencyId;
            var toCurId = exchangeRateEntity.ToCurrencyId;
            _context.Currencies.Where(c => c.CurrencyId == fromCurId).FirstOrDefault().FromRates.Add(exchangeRateEntity);
            _context.Currencies.Where(c => c.CurrencyId == toCurId).FirstOrDefault().ToRates.Add(exchangeRateEntity);
            _context.SaveChanges();
        }

        public void DeleteExchangeRate(ExchangeRate rate)
        {
            _context.ExchangeRates.Remove(rate);
        }

        public void DeleteCurrency(Currency currency)
        {
            _context.Currencies.Remove(currency);
        }

        public ExchangeRate GetReverseRate(ExchangeRate exchangeRateEntity)
        {
            return _context.ExchangeRates.Where(r => r.FromCurrencyId == exchangeRateEntity.ToCurrencyId
                                      && r.ToCurrencyId == exchangeRateEntity.FromCurrencyId).FirstOrDefault();
        }

        public bool RateExists(Guid? rateId)
        {
            return _context.ExchangeRates.Any(r => r.ExchangeRateId == rateId);
        }

        public ExchangeRate GetRate(Guid rateId)
        {
            return _context.ExchangeRates.Where(r => r.ExchangeRateId == rateId).FirstOrDefault();
        }
    }
}

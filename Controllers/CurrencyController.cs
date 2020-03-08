using AutoMapper;
using CurrencyConverter.API.Context;
using CurrencyConverter.API.Entities;
using CurrencyConverter.API.Helpers;
using CurrencyConverter.API.Models;
using CurrencyConverter.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Controllers
{
    [ApiController]
    [Route("api/currencies")]
    public class CurrencyController: ControllerBase
    {
        private readonly ICurrencyConverterRepo _currencyConverterRepo;
        private readonly IMapper _mapper;

        public CurrencyController(ICurrencyConverterRepo currencyConverterRepo,
            IMapper mapper)
        {
            _currencyConverterRepo = currencyConverterRepo ??
                throw new ArgumentNullException(nameof(_currencyConverterRepo));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("{currencyId}", Name = "GetCurrency")]
        public IActionResult GetCurrency(Guid currencyId)
        {
            var CurrencyFromRepo = _currencyConverterRepo.GetCurrency(currencyId);
            return Ok(CurrencyFromRepo);
        }

        [HttpGet()]
        [HttpHead]
        public IActionResult GetCurrencies(string searchQuery)
        {
            var currencies = _currencyConverterRepo.GetCurrencies(searchQuery);
            var currenciesToReturn = _mapper.Map<IEnumerable<CurrencyDto>>(currencies);

            return Ok(currenciesToReturn);
        }

        [HttpPost()]
        public IActionResult CreateCurrency([FromBody]CurrencyForCreationDto currency)
        {
            if (currency == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var currencyEntity = _mapper.Map<Currency>(currency);

            _currencyConverterRepo.AddCurrency(currencyEntity);
            _currencyConverterRepo.Save();

            var currencyToReturn = _mapper.Map<Currency>(currencyEntity);
            return CreatedAtRoute("GetCurrency",
                     new { currencyId = currencyToReturn.CurrencyId},
                     currencyToReturn);
        }

        [HttpGet("{currencyId}/convert")]
        public IActionResult ConvertCurrency([FromBody]ConversionDto requestedConversion)
        {
            if (requestedConversion == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var exchangeRate = _currencyConverterRepo
                .GetRate(requestedConversion.FromCurrencyId, requestedConversion.ToCurrencyId);
            var result = CurrencyExtensions.Convert(exchangeRate.Ratio, requestedConversion.Amount);

            return Ok(result);
        }

        [HttpDelete("{currencyId}")]
        public IActionResult Delete(Guid currencyId)
        {
            var currencyFromRepo = _currencyConverterRepo.GetCurrency(currencyId);

            if (currencyFromRepo == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            foreach (var rate in _currencyConverterRepo.GetRates(currencyId))
            {
                _currencyConverterRepo.DeleteExchangeRate(rate);
            }

            _currencyConverterRepo.DeleteCurrency(currencyFromRepo);
            _currencyConverterRepo.Save();

            return NoContent();
        }
    }
}

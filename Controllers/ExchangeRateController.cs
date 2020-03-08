using AutoMapper;
using CurrencyConverter.API.Entities;
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
    [Route("api/currencies/{currencyId}/rates")]
    public class ExchangeRateController: ControllerBase
    {
        private readonly ICurrencyConverterRepo _currencyConverterRepo;
        private readonly IMapper _mapper;

        public ExchangeRateController(ICurrencyConverterRepo currencyConverterRepo,
            IMapper mapper)
        {
            _currencyConverterRepo = currencyConverterRepo ??
                throw new ArgumentNullException(nameof(_currencyConverterRepo));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public IActionResult GetRates(Guid currencyId)
        {
            if (!_currencyConverterRepo.CurrencyExists(currencyId))
            {
                return NotFound();
            }
            var ratesToReturn = _currencyConverterRepo.GetRates(currencyId);

            return Ok(_mapper.Map<IEnumerable<ExchangeRateDto>>(ratesToReturn));
        }

        [HttpGet("{rateId}", Name ="GetRate")]
        public IActionResult GetRate(Guid rateId)
        {
            if (!_currencyConverterRepo.RateExists(rateId))
            {
                return NotFound();
            }
            var ratesToReturn = _currencyConverterRepo.GetRate(rateId);

            return Ok(_mapper.Map<ExchangeRateDto>(ratesToReturn));
        }

        [HttpPost()]
        [HttpHead]
        public IActionResult CreateRate([FromBody]ExchangeRateForCreationDto exchangeRate, bool createReverse = false)
        {
            if (exchangeRate == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!_currencyConverterRepo.CurrencyExists(exchangeRate.FromCurrencyId) 
                || !_currencyConverterRepo.CurrencyExists(exchangeRate.ToCurrencyId))
            {
                return StatusCode(404, "Currency doesn't exist");
            }

            var exchangeRateEntity = _mapper.Map<ExchangeRate>(exchangeRate);

            _currencyConverterRepo.AddRate(exchangeRateEntity, createReverse);
            _currencyConverterRepo.Save();


            var exchangeRateToReturn = _mapper.Map<ExchangeRateDto>(exchangeRateEntity);

            if (createReverse)
            {
                var reverseRateToReturn = _currencyConverterRepo.GetReverseRate(exchangeRateEntity);
                return CreatedAtAction("GetRate",
                    new { rateId = reverseRateToReturn.ExchangeRateId }, reverseRateToReturn);
            }

            return CreatedAtAction("GetRate", new { rateId = exchangeRateToReturn.ExchangeRateId}, exchangeRateToReturn);
        }


    }
}

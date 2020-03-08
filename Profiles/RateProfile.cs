using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Profiles
{
    public class RateProfile: Profile
    {
        public RateProfile()
        {
            CreateMap<Models.ExchangeRateForCreationDto, Entities.ExchangeRate>();
            CreateMap<Entities.ExchangeRate, Models.ExchangeRateForCreationDto>();
            CreateMap<Models.ExchangeRateDto, Entities.ExchangeRate>();
            CreateMap<Entities.ExchangeRate, Models.ExchangeRateDto>();
        }
    }
}

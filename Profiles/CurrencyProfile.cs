using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyConverter.API.Models
{
    public class CurrencyProfile: Profile
    {
        public CurrencyProfile()
        {
            CreateMap<Models.CurrencyDto,Entities.Currency>();
            CreateMap<Models.CurrencyForCreationDto, Entities.Currency>();
            CreateMap<Entities.Currency, Models.CurrencyDto>();
            CreateMap<Entities.Currency, Models.CurrencyDto>();
        }
    }
}

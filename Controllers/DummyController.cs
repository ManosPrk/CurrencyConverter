
using CurrencyConverter.API.Context;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.API.Controllers
{
    public class DummyController : ControllerBase
    {
        private CurrencyConverterContext _ctx;
        public DummyController(CurrencyConverterContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        [Route("api/testdatabase")]
        public IActionResult TestDatabase()
        {
            return Ok();
        }
    }
}
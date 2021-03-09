using Microsoft.AspNetCore.Mvc;
using System;

namespace Chenpes.Api.Desafio.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class taxaJurosController : ControllerBase
    {
        [HttpGet]
        public decimal Get()
        {
            return 1M/100; 
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace QuoteService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteContext _context;
        private Version _version;

        public QuotesController(QuoteContext context, IConfiguration config)
        {
            _context = context;
            var envVersion = new Version(Environment.GetEnvironmentVariable("VERSION"));
            if (envVersion != null){
                _version=new Version(envVersion.ToString());
            } else{
                _version=new Version("0.0.0");
            }
        }

        [HttpGet("rand")]
        public async Task<ActionResult<Quote>> Get()
        {
            Quote quote = await _context.Quotes
                                 .OrderBy(x => Guid.NewGuid())
                                 .FirstAsync();
            quote.Attribution += _version.ToString();
            return quote;
        }

        [HttpGet("rand/{number}")]
        public async Task<ActionResult<IEnumerable<Quote>>> Get(int number)
        {
            if(number <= 0 || number >= 10)
            {
                return BadRequest();
            }

            return await _context.Quotes
                     .OrderBy(x => Guid.NewGuid())
                     .Take(number)
                     .ToListAsync();
        }
    }
}

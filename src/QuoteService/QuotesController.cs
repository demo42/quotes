using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace QuoteService.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly QuoteContext _context;

        public QuotesController(QuoteContext context)
        {
            _context = context;
        }

        [HttpGet("rand")]
        public async Task<ActionResult<Quote>> Get()
        {
            return await _context.Quotes
                                 .OrderBy(x => Guid.NewGuid())
                                 .FirstAsync();
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

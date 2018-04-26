using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuoteService
{
    public class Quote
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Attribution { get; set; }
    }
}

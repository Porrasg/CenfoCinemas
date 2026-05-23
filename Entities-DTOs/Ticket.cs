using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTOs
{
    public class Ticket : BaseDTO
    {
        public decimal Price { get; set; }
        public string Schedule { get; set; }
        public DateTime Date { get; set; }
        public string Type { get; set; } // Adult, Kids
        public Movie Movie { get; set; }
    }
}

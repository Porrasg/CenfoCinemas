using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTOs
{
    public class Movie : BaseDTO
    {
        public string Title { get; set; }
        public string Sinopsis { get; set; }
        public string Genre { get; set; }
        public int Duration { get; set; }
        public string Clasification { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }

    }
}

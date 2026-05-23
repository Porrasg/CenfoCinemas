using System;
using System.Collections.Generic;
using System.Text;

namespace Entities_DTOs
{
    public class User : BaseDTO
    {
        public string UserCode { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime BirthDate { get; set; }
        public string Status { get; set; }
        public int PhoneNumber { get; set; }
    }
}

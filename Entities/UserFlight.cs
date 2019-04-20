using System;
using System.Collections.Generic;
using System.Text;

namespace Transversal.Entities
{
    public class UserFlight
    {
        public int IdUser { get; set; }
        public string DocumentType { get; set; }
        public int DocumentNumber { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
}

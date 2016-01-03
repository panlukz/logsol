﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogisticSolutions.Models
{
    public class PostalAddress
    {
        public PostalAddress()
        {
            
        }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string ContactPerson { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }
    }
}

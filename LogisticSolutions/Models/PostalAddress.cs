using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogisticSolutions.Models
{
    public class PostalAddress
    {
        private string _address;

        public PostalAddress(string address)
        {
            _address = address;
        }

        public string Address
        {
            get { return _address; }
        }
    }
}

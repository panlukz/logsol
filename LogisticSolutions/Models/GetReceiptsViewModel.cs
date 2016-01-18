using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticSolutions.Models
{
    public class GetReceiptsViewModel
    {
        public string DeliveryNumber { get; set; }

        public string Name { get; set; }

        public string ContactPerson { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string PostalCode { get; set; }

        public string City { get; set; }       
    }
}
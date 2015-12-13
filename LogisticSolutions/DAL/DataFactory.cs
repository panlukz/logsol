using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticSolutions.DAL
{
    public class DataFactory : IDataFactory
    {

        public IDataContext GetDataContext()
        {
            return new DataContext();
        }

    }
}
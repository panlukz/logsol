using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogisticSolutions.DAL
{
    public interface IDataFactory
    {
        IDataContext GetDataContext();
    }
}
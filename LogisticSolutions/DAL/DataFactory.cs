using LogisticSolutions.Interfaces;

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
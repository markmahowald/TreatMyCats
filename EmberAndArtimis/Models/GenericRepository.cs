using System;
namespace EmberAndArtimis.Models
{
    public class GenericRepository<T> : IGenericRepository<T> where T : DataObject
    {
        public GenericRepository()
        {
        }

        public System.Collections.Generic.IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Create(T item)
        {
            throw new NotImplementedException();
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public T Update(int id, T item)
        {
            throw new NotImplementedException();
        }
    }
}

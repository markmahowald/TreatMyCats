using System;
using System.Collections.Generic;

namespace EmberAndArtimis.Models
{
    public interface IGenericRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetById(int id);

        T Update(int id, T item);

        bool Delete(int id);

        T Create(T item);

        
    }
}

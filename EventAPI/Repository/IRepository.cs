using System;
using System.Linq;
using System.Threading.Tasks;
using EventAPI.Models;
using System.Collections.Generic;

namespace EventAPI.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        void Add(T item);
        void Remove(int id);
        void Update(T item);
        T FindByID(int id);
        IEnumerable<T> FindAll();
    }
}

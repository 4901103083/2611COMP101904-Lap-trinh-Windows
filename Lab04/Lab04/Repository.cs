using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab04_ProductManager
{
    public class Repository<T> where T : IEntity
    {
        private List<T> items = new List<T>();

        public void Add(T item)
        {
            items.Add(item);
        }

        public void Remove(T item)
        {
            items.Remove(item);
        }

        public T FindById(string id)
        {
            return items.FirstOrDefault(i => i.Id.Equals(id, StringComparison.OrdinalIgnoreCase));
        }
        public IEnumerable<T> Find(Func<T, bool> predicate)
        {
            return items.Where(predicate);
        }

        public IEnumerable<T> GetAll()
        {
            return items;
        }
    }
}
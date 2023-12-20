using Demo.Bll.Interfaces;
using Demo.Dal.Context;
using Demo.Dal.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Bll.Repository
{
    public class GenaricRepository<T> : IGenaricRepository<T> where T : class
    {
        private readonly Mydbcontext _mydbcontext;

        public GenaricRepository(Mydbcontext mydbcontext)
        {
            _mydbcontext = mydbcontext;
        }

        public IEnumerable<T> GetAll()
        {
            if (typeof(T) == typeof(Employee))
                return (IEnumerable<T>)_mydbcontext.Employees.Include(d => d.department).ToList();
            else
                return _mydbcontext.Set<T>();
        }

        public void Create(T Item)
        {
            _mydbcontext.Set<T>().Add(Item);
        }

        public void Delete(T item)
        {
            _mydbcontext.Remove(item);

        }

        public T Get(int id)
            => _mydbcontext.Set<T>().Find(id);


        public void Update(T item)
        {
            _mydbcontext.Set<T>().Update(item);
        }

    }
}

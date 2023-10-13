using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI44UF_HFT_2023241.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected OrderDbContext _ctx;
        public Repository(OrderDbContext ctx)
        {
            _ctx = ctx;
        }

        public void Create(T item)
        {
            _ctx.Set<T>().Add(item);
            _ctx.SaveChanges();
        }

        public IQueryable<T> ReadAll()
        {
            return _ctx.Set<T>();
        }

        public void DeleteById(int id)
        {
            _ctx.Set<T>().Remove(ReadById(id));
            _ctx.SaveChanges();
        }

        public T ReadById(int id)
        {
            return _ctx.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _ctx.Update(entity);
            _ctx.SaveChanges();
        }

        public void Save()
        { 
            _ctx.SaveChanges();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using WebYonetimPaneli.DAL.Repository.Abstract;

namespace WebYonetimPaneli.DAL.Repository.Concerete
{
    public class EfGenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly DbContext context;

        public EfGenericRepository(DbContext ctx)
        {
            context = ctx;
        }
        public IQueryable<T> Ara(Expression<Func<T, bool>> predicate)
        {
            return context.Set<T>().Where(predicate);
        }
        public void Duzenle(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Ekle(T entity)
        {
            context.Set<T>().Add(entity);
        }
        public void Kaydet()
        {
            context.SaveChanges();
        }
        public void Sil(T entity)
        {
            context.Set<T>().Remove(entity);
        }
        public IQueryable<T> TumVerileriGetir()
        {
            return context.Set<T>();
        }
        public T VeriGetir(int id)
        {
            return context.Set<T>().Find(id);
        }
    }
}

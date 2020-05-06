using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace WebYonetimPaneli.DAL.Repository.Abstract
{
    public interface IGenericRepository<T> where T : class
    {
        T VeriGetir(int id);
        IQueryable<T> TumVerileriGetir();
        IQueryable<T> Ara(Expression<Func<T, bool>> predicate);
        void Ekle(T entity);
        void Duzenle(T entity);
        void Sil(T entity);
        void Kaydet();
    }
}

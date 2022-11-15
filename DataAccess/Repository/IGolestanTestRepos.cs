using DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;



namespace DataAccess.Repository
{
    public interface IGolestanTestRepos<T> where T : class
    {

        T GetById(object id);
        IQueryable<T> GetAll();
        IQueryable<T> Find(Expression<Func<T, bool>> expression);
        bool Exists(Expression<Func<T, bool>> expression);
        T Add(T entity);
        List<T> AddRange(IEnumerable<T> entities);
        public void Update(T entity);
        void Remove(T entity);
        public void RemoveById(object id);

        void RemoveRange(IEnumerable<T> entities);
        void SaveChanges();

    }
}

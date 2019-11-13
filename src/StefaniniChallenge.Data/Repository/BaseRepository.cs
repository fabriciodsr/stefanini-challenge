using Microsoft.EntityFrameworkCore;
using StefaniniChallenge.Domain.Entities;
using StefaniniChallenge.Domain.Interfaces.Repositories;
using StefaniniChallenge.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StefaniniChallenge.Data.Repository
{
    public class BaseRepository<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected readonly ApplicationContext context;

        public BaseRepository(ApplicationContext context)
            : base()
        {
            this.context = context;
        }

        public int Insert(T obj)
        {
            context.BeginTransaction();
            context.Set<T>().Add(obj);
            context.SendChanges();
            return obj.Id;
        }

        public T Update(T obj)
        {
            context.BeginTransaction();
            context.Set<T>().Attach(obj);
            context.Entry(obj).State = EntityState.Modified;
            context.SendChanges();
            return obj;
        }

        public void DeleteById(int id)
        {
            var obj = SelectById(id);
            if (obj != null)
            {
                context.BeginTransaction();
                context.Set<T>().Remove(obj);
                context.SendChanges();
            }
        }

        public void Delete(T entity)
        {
            context.BeginTransaction();
            context.Set<T>().Remove(entity);
            context.SendChanges();
        }

        public IEnumerable<T> SelectAll()
        {
            return QueryIncludingNavigations(true).ToList();
        }

        public T SelectById(int id)
        {
            return QueryIncludingNavigations(true).FirstOrDefault(obj => obj.Id.Equals(id));
        }

        public virtual IQueryable<T> QueryIncludingNavigations(bool eager = false)
        {
            var query = context.Set<T>().AsQueryable();
            if (eager)
            {
                foreach (var property in context.Model.FindEntityType(typeof(T)).GetNavigations())
                    query = query.Include(property.Name);
            }
            return query;
        }
    }
}

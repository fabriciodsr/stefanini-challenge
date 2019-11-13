using StefaniniChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StefaniniChallenge.Domain.Interfaces.Repositories
{
    public interface IRepositoryBase<T> where T : BaseEntity
    {
        int Insert(T obj);

        T Update(T obj);

        void DeleteById(int id);

        void Delete(T entity);

        T SelectById(int id);

        IEnumerable<T> SelectAll();
    }
}

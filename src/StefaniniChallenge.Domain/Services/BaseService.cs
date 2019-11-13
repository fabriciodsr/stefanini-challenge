using FluentValidation;
using StefaniniChallenge.Domain.Entities;
using StefaniniChallenge.Domain.Interfaces.Repositories;
using StefaniniChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StefaniniChallenge.Domain.Services
{
    public class BaseService<T> : IServiceBase<T> where T : BaseEntity
    {
        protected readonly IRepositoryBase<T> repository;

        public BaseService(IRepositoryBase<T> repository)
        {
            this.repository = repository;
        }

        public void Delete(T obj)
        {
            repository.Delete(obj);
        }

        public void DeleteById(int id)
        {
            repository.DeleteById(id);
        }

        public int Insert(T obj)
        {
            return repository.Insert(obj);
        }

        public IEnumerable<T> SelectAll()
        {
            return repository.SelectAll();
        }

        public T SelectById(int id)
        {
            return repository.SelectById(id);
        }

        public T Update(T obj)
        {
            return repository.Update(obj);
        }
    }
}

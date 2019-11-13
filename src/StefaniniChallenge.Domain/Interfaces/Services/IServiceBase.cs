using FluentValidation;
using StefaniniChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StefaniniChallenge.Domain.Interfaces.Services
{
    public interface IServiceBase<T> where T : BaseEntity
    {
        int Insert(T obj);
        T Update(T obj);
        void DeleteById(int id);
        void Delete(T obj);
        T SelectById(int id);
        IEnumerable<T> SelectAll();
    }
}

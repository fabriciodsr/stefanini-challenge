using AutoMapper;
using FluentValidation;
using StefaniniChallenge.Application.DTO;
using StefaniniChallenge.Application.Interfaces;
using StefaniniChallenge.Domain.Entities;
using StefaniniChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StefaniniChallenge.Application.Services
{
    public class AppBaseService<T, TDTO> : IAppBase<T, TDTO> 
        where T : BaseEntity
        where TDTO : BaseDTO
    {
        protected readonly IServiceBase<T> service;
        protected readonly IMapper iMapper;

        public AppBaseService(IMapper iMapper, IServiceBase<T> service)
            : base()
        {
            this.service = service;
            this.iMapper = iMapper;
        }

        public void Delete(TDTO obj)
        {
            service.Delete(iMapper.Map<T>(obj));
        }

        public void DeleteById(int id)
        {
            service.DeleteById(id);
        }

        public int Insert(TDTO obj) 
        {
            return service.Insert(iMapper.Map<T>(obj));
        }

        public IEnumerable<TDTO> SelectAll()
        {
            return iMapper.Map<IEnumerable<TDTO>>(service.SelectAll());
        }

        public TDTO SelectById(int id)
        {
            return iMapper.Map<TDTO>(service.SelectById(id));
        }

        public T Update(TDTO obj)
        {
            return service.Update(iMapper.Map<T>(obj));
        }
    }
}

using StefaniniChallenge.Application.DTO;
using StefaniniChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StefaniniChallenge.Application.Interfaces
{
    public interface IAppBase<T, TDTO>
        where T : BaseEntity
        where TDTO : BaseDTO
    {
        int Insert(TDTO obj);

        T Update(TDTO obj);

        void DeleteById(int id);

        void Delete(TDTO obj);

        TDTO SelectById(int id);

        IEnumerable<TDTO> SelectAll();
    }
}

using AutoMapper;
using StefaniniChallenge.Application.DTO;
using StefaniniChallenge.Application.Interfaces;
using StefaniniChallenge.Domain.Entities;
using StefaniniChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace StefaniniChallenge.Application.Services
{
    public class AppCity : AppBaseService<City, CityDTO>, IAppCity
    {
        public AppCity(IMapper iMapper, ICityService service)
            : base(iMapper, service)
        {

        }
    }
}

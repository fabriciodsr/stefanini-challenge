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
    public class AppRegion : AppBaseService<Region, RegionDTO>, IAppRegion
    {
        public AppRegion(IMapper iMapper, IRegionService service)
            : base(iMapper, service)
        {

        }
    }
}

using FluentValidation;
using StefaniniChallenge.Domain.Entities;
using StefaniniChallenge.Domain.Interfaces.Repositories;
using StefaniniChallenge.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace StefaniniChallenge.Domain.Services
{
    public class RegionService : BaseService<Region>, IRegionService
    {
        public RegionService(IRegionRepository repository)
            : base(repository)
        {

        }
    }
}

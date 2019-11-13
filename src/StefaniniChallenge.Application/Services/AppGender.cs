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
    public class AppGender : AppBaseService<Gender, GenderDTO>, IAppGender
    {
        public AppGender(IMapper iMapper, IGenderService service)
            : base(iMapper, service)
        {

        }
    }
}

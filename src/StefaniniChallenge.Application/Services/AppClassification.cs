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
    public class AppClassification : AppBaseService<Classification, ClassificationDTO>, IAppClassification
    {
        public AppClassification(IMapper iMapper, IClassificationService service)
            : base(iMapper, service)
        {

        }
    }
}

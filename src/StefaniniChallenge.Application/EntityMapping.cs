using AutoMapper;
using StefaniniChallenge.Application.DTO;
using StefaniniChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace StefaniniChallenge.Application
{
    public class EntityMapping : Profile
    {
        public EntityMapping()
        {
            CreateMap<City, CityDTO>();
            CreateMap<CityDTO, City>();

            CreateMap<Classification, ClassificationDTO>();
            CreateMap<ClassificationDTO, Classification>();

            CreateMap<Customer, CustomerDTO>();
            CreateMap<CustomerDTO, Customer>();

            CreateMap<Gender, GenderDTO>();
            CreateMap<GenderDTO, Gender>();

            CreateMap<Region, RegionDTO>();
            CreateMap<RegionDTO, Region>();
        }
    }
}

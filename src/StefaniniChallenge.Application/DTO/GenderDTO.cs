using Microsoft.AspNetCore.Identity;
using StefaniniChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StefaniniChallenge.Application.DTO
{
    public class GenderDTO : BaseDTO
    {
        public string Name { get; set; }
    }
}

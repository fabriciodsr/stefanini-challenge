using Microsoft.AspNetCore.Identity;
using StefaniniChallenge.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace StefaniniChallenge.Application.DTO
{
    public class CustomerDTO : BaseDTO
    {
        public IEnumerable<CustomerDTO> Customers { get; set; }

        public string Name { get; set; }

        public virtual Gender Gender { get; set; }

        [Display(Name = "Gender")]
        public int GenderId { get; set; }

        public virtual City City { get; set; }

        [Display(Name = "City")]
        public int CityId { get; set; }

        public virtual Region Region { get; set; }

        [Display(Name = "Region")]
        public int RegionId { get; set; }

        public string Phone { get; set; }

        [Display(Name = "Last Purchase")]
        [DataType(DataType.Date)]
        public DateTime? LastPurchase { get; set; }

        public DateTime? Until { get; set; }

        public virtual Classification Classification { get; set; }

        [Display(Name = "Classification")]
        public int ClassificationId { get; set; }

        [Display(Name = "Seller")]
        public int SellerId { get; set; }

        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}

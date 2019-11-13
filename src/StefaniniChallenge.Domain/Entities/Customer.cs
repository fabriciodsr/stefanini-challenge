using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefaniniChallenge.Domain.Entities
{
    public class Customer : BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Phone { get; set; }
        public int GenderId { get; set; }
        public Gender Gender { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public int? RegionId { get; set; }
        public Region Region { get; set; }
        [Column(TypeName = "date")]
        public System.DateTime? LastPurchase { get; set; }
        [Display(Name = "Classification")]
        public int? ClassificationId { get; set; }
        public Classification Classification { get; set; }
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }
    }
}
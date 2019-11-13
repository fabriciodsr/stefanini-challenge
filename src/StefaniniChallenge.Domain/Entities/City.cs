using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefaniniChallenge.Domain.Entities
{
    public class City : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        public int RegionId { get; set; }

        [ForeignKey("RegionId")]
        [InverseProperty("City")]
        public virtual Region Region { get; set; } 
    }
}
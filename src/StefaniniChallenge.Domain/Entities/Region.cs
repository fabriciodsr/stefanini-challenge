using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StefaniniChallenge.Domain.Entities
{
    public class Region : BaseEntity
    {
        public Region()
        {
            City = new HashSet<City>();
        }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [InverseProperty("Region")]
        public virtual ICollection<City> City { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace StefaniniChallenge.Domain.Entities
{
    public class Classification : BaseEntity
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
    }
}
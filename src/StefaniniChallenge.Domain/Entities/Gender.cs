using System.ComponentModel.DataAnnotations;

namespace StefaniniChallenge.Domain.Entities
{
    public class Gender : BaseEntity
    {
        [Required]
        [StringLength(10)]
        public string Name { get; set; }
    }
}
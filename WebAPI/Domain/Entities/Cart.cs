using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Cart
    {
        [Required]
        public Guid CartId { get; set; }
        public Item CartItem { get; set; }
    }
}
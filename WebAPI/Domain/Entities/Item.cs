using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Item
    {
        [Required]
        public Guid CartId { get; set; }

        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        public string ImageURL { get; set; }

        public string ImageAltText { get; set; }
    }
}
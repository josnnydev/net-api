using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.Models;
public class Product
    {

        public Product() {
            Name = string.Empty;
            Description = string.Empty;
            Price = 0;
            Image = string.Empty;
         }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [MaxLength(100, ErrorMessage = "Name must be less than 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [MaxLength(100, ErrorMessage = "Description must be less than 100 characters")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, double.MaxValue, ErrorMessage = "Price must be a positive number")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Image is required")]
        [MaxLength(100, ErrorMessage = "Image must be less than 100 characters")]
        public string Image { get; set; }
    }
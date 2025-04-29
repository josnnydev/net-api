using System.ComponentModel.DataAnnotations;

namespace MyFirstApi.Dtos
{
    public class UpdateProductDTO
    {
        public UpdateProductDTO(){
            Name = string.Empty;
            Description = string.Empty;
            Price = 0;
            Image = string.Empty;
        }
        [Required(ErrorMessage = "Name is required.")]
        [StringLength(100, ErrorMessage = "Name must be less than 100 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(100, ErrorMessage = "Description must be less than 100 characters.")]
        public string Description { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Price must be greater than 0.")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Image is required.")]
        [MaxLength(100, ErrorMessage = "Image must be less than 100 characters.")]
        public string Image { get; set; }
    }
}

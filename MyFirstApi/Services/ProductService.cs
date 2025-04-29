using MyFirstApi.Models;
using MyFirstApi.Dtos;

namespace MyFirstApi.Services
{
    public class ProductService
    {
        private static List<Product> Products = new()
        {
            new Product { Id = 1, Name = "Producto 1", Description = "Description 1", Price = 10.0 },
            new Product { Id = 2, Name = "Producto 2", Description = "Description 2", Price = 20.0 }
        };

        public List<Product> GetAll()
        {
            return Products;
        }

        public Product? GetById(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }

        public Product Create(CreateProductDTO dto)
        {
            int newId = Products.Any() ? Products.Max(p => p.Id) + 1 : 1;
            var newProduct = new Product
            {
                Id = newId,
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Image = dto.Image
            };

            Products.Add(newProduct);
            return newProduct;
        }

        public bool Update(int id, UpdateProductDTO dto)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            return true;
        }

        public bool Delete(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            if (product == null) return false;

            Products.Remove(product);
            return true;
        }
    }
}

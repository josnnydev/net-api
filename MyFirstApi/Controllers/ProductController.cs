using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Models;
using MyFirstApi.Dtos;
using MyFirstApi.Services;

namespace MyFirstApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public ActionResult<List<Product>> GetProducts()
        {
            return Ok(_productService.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _productService.GetById(id);
            if (product is null)
                return NotFound();

            return Ok(product);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct([FromBody] CreateProductDTO newProductDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // <--- Esto revisa si los datos enviados cumplen las reglas
            }

            var newProduct = _productService.Create(newProductDTO);
             
            return CreatedAtAction(nameof(GetProduct), new { id = newProduct.Id }, newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, [FromBody] UpdateProductDTO updatedProductDTO)
        {
          if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = _productService.Update(id, updatedProductDTO);
            if (!updated)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _productService.GetById(id);
            if (product is null)
                return NotFound();

            _productService.Delete(id);
            return NoContent();
        }
    }


}

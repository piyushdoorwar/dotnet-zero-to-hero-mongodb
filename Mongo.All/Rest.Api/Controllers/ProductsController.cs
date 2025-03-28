using Microsoft.AspNetCore.Mvc;
using Mongo.Service.Model;
using Mongo.Service;

namespace Rest.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly ProductService _productService;

    public ProductsController(ProductService productService) => _productService = productService;

    // GET: api/products
    [HttpGet]
    public async Task<ActionResult<List<Product>>> GetAllProducts()
    {
        var products = await _productService.GetAllAsync();
        return Ok(products);
    }

    // GET: api/products/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Product>> GetProductById(string id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound();
        return Ok(product);
    }

    // POST: api/products
    [HttpPost]
    public async Task<ActionResult<Product>> CreateProduct(Product product)
    {
        await _productService.CreateAsync(product);
        return CreatedAtAction(nameof(GetProductById), new { id = product.Id }, product);
    }

    // PUT: api/products/{id}
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateProduct(string id, Product updatedProduct)
    {
        var existing = await _productService.GetByIdAsync(id);
        if (existing == null) return NotFound();

        updatedProduct.Id = id;
        await _productService.UpdateAsync(id, updatedProduct);
        return NoContent();
    }

    // DELETE: api/products/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteProduct(string id)
    {
        var product = await _productService.GetByIdAsync(id);
        if (product == null) return NotFound();

        await _productService.DeleteAsync(id);
        return NoContent();
    }
}
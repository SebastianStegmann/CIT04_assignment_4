// New file: CategoriesController.cs
using DataServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceLayer.Controllers;

[ApiController]
[Route("api/products")]
public class ProductsController : ControllerBase
{
    private readonly DataService _dataService;

    public ProductsController(DataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet("{id}")]
    public IActionResult GetProduct(int id)
    {
        var product = _dataService.GetProduct(id);

        if (product == null) return NotFound();

        return Ok(product);
    }

    [HttpGet("category/{id}")]
    public IActionResult GetProductsByCategory(int id)
    {
        var products = _dataService.GetProductByCategory(id);
        if (!products.Any()) return NotFound(new object[0]);
        return Ok(products.Select(p => new { name = p.Name, categoryName = p.CategoryName }));
    }

    [HttpGet("name/{name}")]
    public IActionResult GetProductsByName(string name)
    {
        var products = _dataService.GetProductByName(name);
        if (!products.Any()) return NotFound(new object[0]);
        return Ok(products.Select(p => new { productName = p.Name }));
    }
}

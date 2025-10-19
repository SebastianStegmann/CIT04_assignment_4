// New file: CategoriesController.cs
using DataServiceLayer;
using Microsoft.AspNetCore.Mvc;

namespace WebServiceLayer.Controllers;

[ApiController]
[Route("api/categories")]
public class CategoriesController : ControllerBase
{
    private readonly DataService _dataService;

    public CategoriesController(DataService dataService)
    {
        _dataService = dataService;
    }

    [HttpGet]
    public IActionResult GetCategories()
    {
        return Ok(_dataService.GetCategories());
    }

    [HttpGet("{id}")]
    public IActionResult GetCategory(int id)
    {
        var category = _dataService.GetCategory(id);
        if (category == null) return NotFound();
        return Ok(category);
    }

    [HttpPost]
    public IActionResult CreateCategory([FromBody] Category category)
    {
        var created = _dataService.CreateCategory(category.Name, category.Description);
        return CreatedAtAction(nameof(GetCategory), new { id = created.Id }, created);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, [FromBody] Category category)
    {
        var updated = _dataService.UpdateCategory(id, category.Name, category.Description);
        if (!updated) return NotFound();
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var deleted = _dataService.DeleteCategory(id);
        if (!deleted) return NotFound();
        return Ok();
    }
}

using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Categories;

public partial class CategoriesController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory([FromRoute] Guid id)
    {
        var response = await _categoryService.GetCategoryById(id);

        if (response.IsSuccess) {
            return Ok(response);
        }

        return BadRequest(response);
    }
}
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Categories;

public partial class CategoriesController
{
    [HttpGet]
    public async Task<IActionResult> GetList()
    {
        var categories = await _categoryService.GetCategories();

        return Ok(categories);
    }
}
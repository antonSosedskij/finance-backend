using finance_backend.Application.Services.Category.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Categories;

public partial class CategoriesController
{
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCategory(Guid id)
    {
        await _categoryService.DeleteCategory(new DeleteCategory.Request
        {
            Id = id
        });

        return NoContent();
    }
}
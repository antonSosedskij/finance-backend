using finance_backend.API.Dto;
using finance_backend.API.Dto.Category;
using finance_backend.Application.Services.Category.Contracts;
using finance_backend.Domain;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Categories;

public partial class CategoryController
{
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateCategoryRequest request)
    {
        var category = await _categoryService.Create(new CreateCategory.Request
        {
            Title = request.Title
        });

        return Created($"api/v1/Category", category);
    }
}
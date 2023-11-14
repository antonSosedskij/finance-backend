using System.Net;
using finance_backend.API.Dto.Category;
using finance_backend.Application.Services.Category.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Categories;

public partial class CategoryController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCategory([FromRoute] Guid id)
    {
        var response = await _categoryService.GetCategory(new GetCategory.Request
        {
            Id = id
        });

        return Ok(response);
    }
}
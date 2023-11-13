using finance_backend.Application.Services.Category.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Categories;

[ApiController]
[Route("api/[controller]")]
public partial class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(
        ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }
}
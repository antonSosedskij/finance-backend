using finance_backend.Application.Services.Balance.Interfaces;
using finance_backend.Application.Services.Category.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Balances;

[ApiController]
[Route("api/[controller]")]
public partial class BalancesController : ControllerBase
{
    private readonly IBalanceService _balanceService;
    private readonly ICategoryService _categoryService;

    public BalancesController(
        IBalanceService balanceService,
        ICategoryService categoryService)
    {
        _balanceService = balanceService;
        _categoryService = categoryService;
    }
}
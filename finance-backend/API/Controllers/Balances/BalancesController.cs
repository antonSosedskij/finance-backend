using finance_backend.Application.Services.Balance.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Balances;

[ApiController]
[Route("api/[controller]")]
public partial class BalancesController : ControllerBase
{
    private readonly IBalanceService _balanceService;

    public BalancesController(
        IBalanceService balanceService)
    {
        _balanceService = balanceService;
    }
}
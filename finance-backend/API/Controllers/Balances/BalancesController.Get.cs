using finance_backend.Application.Services.Balance.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Balances;

public partial class BalancesController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBalance(Guid id)
    {
        var balance = await _balanceService.GetBalance(new GetBalance.Request
        {
            Id = id
        });

        return Ok(balance);
    }
}
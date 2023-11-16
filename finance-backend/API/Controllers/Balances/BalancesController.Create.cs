using finance_backend.API.Dto.Balance;
using finance_backend.Application.Services.Balance.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Balances;

public partial class BalancesController
{
    [HttpPost]
    public async Task<IActionResult> CreateBalance([FromBody]CreateBalanceRequest request)
    {
        var balance = await _balanceService.CreateBalance( new CreateBalance.Request
        {
            Title = request.Title,
            Percent = request.Percent,
            CategoryId = request.CategoryId
        });

        return Created("api/Balances", balance);
    }
}
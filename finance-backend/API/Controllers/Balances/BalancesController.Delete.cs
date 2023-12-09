using finance_backend.API.Dto;
using finance_backend.Application.Services.Balance.Contracts;
using Microsoft.AspNetCore.Mvc;
using static finance_backend.API.Dto.ErrorResponse;

namespace finance_backend.API.Controllers.Balances;

public partial class BalancesController
{
    [HttpDelete("{balanceId}")]
    public async Task<IActionResult> DeleteBalance(Guid balanceId)
    {
        var result = await _balanceService.DeleteBalance(balanceId);

        if (result.IsSuccess)
        {
            return Ok("Баланс успешно удален");
        }

        return BadRequest(result.Errors);
    }
}
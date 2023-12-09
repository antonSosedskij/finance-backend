using finance_backend.API.Dto;
using finance_backend.Application.Services.Balance.Contracts;
using Microsoft.AspNetCore.Mvc;
using static finance_backend.API.Dto.ErrorResponse;

namespace finance_backend.API.Controllers.Balances;
public partial class BalancesController
{
    [HttpPost("GetPagedBalancesForCurrentUser")]
    public async Task<ActionResult<PagedBalances>> GetPagedBalancesForCurrentUser([FromBody] BalancePagedRequest request)
    {
        if (request.Page < 1 || request.Size <= 0)
        {
            var error = new ErrorItem("Page должен быть больше 0, Size должен быть больше 0.");
            var errorResponse = new ErrorResponse
            {
                IsSuccess = false,
                Errors = new List<ErrorItem> { error },
            };

            return BadRequest(errorResponse);
        }

        var expenses = await _balanceService.GetPagedBalancesForCurrentUser(request);

        return Ok(expenses);
    }
}

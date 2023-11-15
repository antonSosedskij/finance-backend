using Microsoft.AspNetCore.Mvc;

namespace finance_backend.Controllers;

public partial class IncomesController
{
    [HttpGet("currentUser")]
    public async Task<IActionResult> GetByCurrentUser()
    {
        var incomes = await _incomeService.GetCurrentUserIncomes();

        return Ok(incomes);
    }
}
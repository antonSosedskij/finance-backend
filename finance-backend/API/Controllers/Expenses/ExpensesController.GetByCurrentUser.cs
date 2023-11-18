using Microsoft.AspNetCore.Mvc;

namespace Finance_Backend.Controllers;

public partial class ExpensesController
{
    [HttpGet()]
    public async Task<IActionResult> GetAllForCurrentUser()
    {
        var expenses = await _expenseService.GetAllForCurrentUser();

        return Ok(expenses);
    }
}
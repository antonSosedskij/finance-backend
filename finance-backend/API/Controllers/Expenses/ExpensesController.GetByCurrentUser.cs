using finance_backend.Application.Services.Expense.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Finance_Backend.Controllers;

public partial class ExpensesController
{
    [HttpPost("paged")]
    public async Task<ActionResult<PagedExpenses>> GetPagedExpensesForCurrentUser([FromBody] ExpensesRequest request)
    {
        var expenses = await _expenseService.GetPagedExpensesForCurrentUser(request);

        return Ok(expenses);
    }

}
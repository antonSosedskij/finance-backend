using finance_backend.Application.Services.Expense.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Finance_Backend.Controllers;

public partial class ExpensesController
{
    [HttpGet("{id}")]
    public async Task<IActionResult> GetExpense(Guid id)
    {
        var expense = await _expenseService.GetExpense(new GetExpense.Request
        {
            Id = id
        });

        return Ok(expense);
    }
}
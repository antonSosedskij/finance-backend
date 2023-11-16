using finance_backend.Application.Services.Expense.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Finance_Backend.Controllers;

public partial class ExpensesController
{
    [HttpPost]
    public async Task<IActionResult> CreateExpense(CreateExpense.Request request)
    {
        var expense = await _expenseService.CreateExpense(new CreateExpense.Request
        {
            Title = request.Title,
            BalanceId = request.BalanceId,
            Amount = request.Amount
        });

        return Ok(expense);
    }
}
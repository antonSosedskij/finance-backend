using finance_backend.Application.Services.Expense.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Finance_Backend.Controllers
{
    public partial class ExpensesController
    {
        /// <summary>
        /// �������� ������ �������.
        /// </summary>
        /// <remarks>
        /// ������ �������:
        ///
        ///     POST /Expenses
        ///     {
        ///        "title": "string",
        ///        "balanceId": "guid",
        ///        "amount": 100.00
        ///     }
        /// </remarks>
        /// <param name="request">������ ������� ��� �������� �������: CreateExpenseRequest.</param>
        /// <returns>���������� � ��������� �������.</returns>
        /// <response code="200">������ ������� ������.</response>
        [HttpPost("create")]
        public async Task<IActionResult> CreateExpense(CreateExpenseRequest request)
        {
            var expense = await _expenseService.CreateExpense(new CreateExpenseRequest
            {
                Title = request.Title,
                BalanceId = request.BalanceId,
                Amount = request.Amount
            });

            return Ok(expense);
        }

    }
}

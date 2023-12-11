using finance_backend.Application.Services.Expense.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Finance_Backend.Controllers
{
    public partial class ExpensesController
    {
        /// <summary>
        /// Создание нового расхода.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Expenses
        ///     {
        ///        "title": "string",
        ///        "balanceId": "guid",
        ///        "amount": 100.00
        ///     }
        /// </remarks>
        /// <param name="request">Модель запроса для создания расхода: CreateExpenseRequest.</param>
        /// <returns>Информация о созданном расходе.</returns>
        /// <response code="200">Расход успешно создан.</response>
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

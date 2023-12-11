using Microsoft.AspNetCore.Mvc;

namespace Finance_Backend.Controllers
{
    public partial class ExpensesController
    {
        /// <summary>
        /// Получение информации о расходе по его идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET /Expenses/{id}
        /// </remarks>
        /// <param name="id">Идентификатор расхода.</param>
        /// <returns>Информация о расходе.</returns>
        /// <response code="200">Информация о расходе успешно получена.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var expense = await _expenseService.GetById(id);

            return Ok(expense);
        }

    }
}

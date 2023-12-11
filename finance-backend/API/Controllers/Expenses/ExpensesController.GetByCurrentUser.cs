using finance_backend.API.Dto;
using finance_backend.Application.Services.Expense.Contracts;
using Microsoft.AspNetCore.Mvc;
using static finance_backend.API.Dto.ErrorResponse;

namespace Finance_Backend.Controllers;

public partial class ExpensesController
{
    /// <summary>
    /// ѕолучение пагинированного списка расходов дл€ текущего пользовател€.
    /// </summary>
    /// <remarks>
    /// ѕример запроса:
    ///
    ///     POST /Expenses/Paged
    ///     {
    ///        "page": 1,
    ///        "pageSize": 10
    ///     }
    /// </remarks>
    /// <param name="request">ћодель запроса дл€ получени€ пагинированного списка расходов: ExpensesRequest.</param>
    /// <returns>ѕагинированный список расходов дл€ текущего пользовател€.</returns>
    /// <response code="200">ѕагинированный список расходов успешно получен.</response>
    /// <response code="400">ќшибка при запросе пагинированного списка расходов. ¬озвращаетс€ в случае неверных параметров запроса.</response>
    [HttpPost("paged")]
    [ProducesResponseType(typeof(PagedExpenses), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PagedExpenses>> GetPagedExpensesForCurrentUser([FromBody] ExpensesRequest request)
    {
        if (request.Page < 1 || request.Size <= 0)
        {
            var error = new ErrorItem("”казанна€ страница должен быть больше 0, а количество элементов на странице должно быть больше 0.");
            var errorResponse = new ErrorResponse
            {
                IsSuccess = false,
                Errors = new List<ErrorItem> { error },
            };

            return BadRequest(errorResponse);
        }

        var expenses = await _expenseService.GetPagedExpensesForCurrentUser(request);

        return Ok(expenses);
    }

}
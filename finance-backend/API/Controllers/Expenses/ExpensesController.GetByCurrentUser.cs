using finance_backend.API.Dto;
using finance_backend.Application.Services.Expense.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace Finance_Backend.Controllers;

public partial class ExpensesController
{
    [HttpPost("paged")]
    public async Task<ActionResult<PagedExpenses>> GetPagedExpensesForCurrentUser([FromBody] ExpensesRequest request)
    {
        if (request.Page < 1 || request.Size <= 0)
        {
            var errorResponse = new ErrorResponse
            {
                Errors = new List<ErrorResponse.ErrorItem>
            {
                new ErrorResponse.ErrorItem
                {
                    Error = "������ ���������",
                    Message = "Page ������ ���� ������ 0, Size ������ ���� ������ 0."
                }
            }
            };

            return BadRequest(errorResponse);
        }

        var expenses = await _expenseService.GetPagedExpensesForCurrentUser(request);

        return Ok(expenses);
    }


}
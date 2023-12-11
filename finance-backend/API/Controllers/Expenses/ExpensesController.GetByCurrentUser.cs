using finance_backend.API.Dto;
using finance_backend.Application.Services.Expense.Contracts;
using Microsoft.AspNetCore.Mvc;
using static finance_backend.API.Dto.ErrorResponse;

namespace Finance_Backend.Controllers;

public partial class ExpensesController
{
    /// <summary>
    /// ��������� ��������������� ������ �������� ��� �������� ������������.
    /// </summary>
    /// <remarks>
    /// ������ �������:
    ///
    ///     POST /Expenses/Paged
    ///     {
    ///        "page": 1,
    ///        "pageSize": 10
    ///     }
    /// </remarks>
    /// <param name="request">������ ������� ��� ��������� ��������������� ������ ��������: ExpensesRequest.</param>
    /// <returns>�������������� ������ �������� ��� �������� ������������.</returns>
    /// <response code="200">�������������� ������ �������� ������� �������.</response>
    /// <response code="400">������ ��� ������� ��������������� ������ ��������. ������������ � ������ �������� ���������� �������.</response>
    [HttpPost("paged")]
    [ProducesResponseType(typeof(PagedExpenses), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PagedExpenses>> GetPagedExpensesForCurrentUser([FromBody] ExpensesRequest request)
    {
        if (request.Page < 1 || request.Size <= 0)
        {
            var error = new ErrorItem("��������� �������� ������ ���� ������ 0, � ���������� ��������� �� �������� ������ ���� ������ 0.");
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
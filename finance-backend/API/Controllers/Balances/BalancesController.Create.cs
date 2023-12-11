using finance_backend.API.Dto;
using finance_backend.Application.Services.Balance.Contracts;
using Microsoft.AspNetCore.Mvc;
using static finance_backend.API.Dto.ErrorResponse;

namespace finance_backend.API.Controllers.Balances;

public partial class BalancesController
{
    /// <summary>
    /// �������� ������ ������� � �������.
    /// </summary>
    /// <remarks>
    /// ������ �������:
    ///
    ///     POST /Balance/Create
    ///     {
    ///        "title": "����� ������",
    ///        "percent": 5.0,
    ///        "categoryId": "00000000-0000-0000-0000-000000000000"
    ///     }
    /// </remarks>
    /// <param name="request">������ ������� ��� �������� �������: CreateBalanceRequest.</param>
    /// <returns>��������� �������� �������.</returns>
    /// <response code="201">������ ������� ������.</response>
    /// <response code="400">������ �������� �������. ������������ � ������ ���������� ��������� ��� ������ ������� � ��������.</response>
    [HttpPost("create")]
    [ProducesResponseType(typeof(CreateBalanceResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> CreateBalance([FromBody] CreateBalanceRequest request)
    {
        var category = await _categoryService.GetCategoryById(request.CategoryId);

        if(!category.IsSuccess)
        {
            var error = new ErrorItem("�� ������� ���������.");
            return BadRequest(new CreateBalanceResponse
            {
                IsSuccess = false,
                Errors = new[] { error }
            });
        }


        var balanceResponse = await _balanceService.CreateBalance(new CreateBalanceRequest
        {
            Title = request.Title,
            Percent = request.Percent,
            CategoryId = request.CategoryId,
        });

        if (balanceResponse.IsSuccess)
        {
            return Created("api/Balances", balanceResponse);
        }

        return BadRequest(balanceResponse);
    }

}
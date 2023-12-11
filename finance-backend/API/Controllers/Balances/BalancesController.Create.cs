using finance_backend.API.Dto;
using finance_backend.Application.Services.Balance.Contracts;
using Microsoft.AspNetCore.Mvc;
using static finance_backend.API.Dto.ErrorResponse;

namespace finance_backend.API.Controllers.Balances;

public partial class BalancesController
{
    /// <summary>
    /// Создание нового баланса в системе.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Balance/Create
    ///     {
    ///        "title": "Новый баланс",
    ///        "percent": 5.0,
    ///        "categoryId": "00000000-0000-0000-0000-000000000000"
    ///     }
    /// </remarks>
    /// <param name="request">Модель запроса для создания баланса: CreateBalanceRequest.</param>
    /// <returns>Результат создания баланса.</returns>
    /// <response code="201">Баланс успешно создан.</response>
    /// <response code="400">Ошибка создания баланса. Возвращается в случае отсутствия категории или других проблем с запросом.</response>
    [HttpPost("create")]
    [ProducesResponseType(typeof(CreateBalanceResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]

    public async Task<IActionResult> CreateBalance([FromBody] CreateBalanceRequest request)
    {
        var category = await _categoryService.GetCategoryById(request.CategoryId);

        if(!category.IsSuccess)
        {
            var error = new ErrorItem("Не найдена категория.");
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
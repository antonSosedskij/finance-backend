using finance_backend.Application.Services.Balance.Contracts;
using Microsoft.AspNetCore.Mvc;
using static finance_backend.API.Dto.ErrorResponse;

namespace finance_backend.API.Controllers.Balances;

public partial class BalancesController
{
    [HttpPost]
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
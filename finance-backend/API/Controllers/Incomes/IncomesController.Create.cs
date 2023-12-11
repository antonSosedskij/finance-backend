using finance_backend.Application.Services.Income.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.Controllers;

public partial class IncomesController
{
    [HttpPost]
    public async Task<IActionResult> CreateIncome([FromBody] CreateIncomeRequest request)
    {
        var income = await _incomeService.CreateIncome(new CreateIncomeRequest
        {
            Title = request.Title,
            Amount = request.Amount
        });

        return Ok(income);
    }
}
using finance_backend.API.Dto;
using finance_backend.Application.Services.Balance.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Balances
{
    public partial class BalancesController
    {
        /// <summary>
        /// Получение информации о балансе по его идентификатору.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     GET /Balances/{id}
        /// </remarks>
        /// <param name="id">Идентификатор баланса (GUID).</param>
        /// <returns>Информация о балансе.</returns>
        /// <response code="200">Информация о балансе успешно получена.</response>
        /// <response code="400">Баланс не найден. Возвращается в случае отсутствия баланса с указанным идентификатором.</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(BalanceView), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBalance(Guid id)
        {
            var result = await _balanceService.GetBalance(id);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Errors);
        }
    }
}

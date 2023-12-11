using finance_backend.API.Dto;
using finance_backend.Application.Services.Balance.Contracts;
using Microsoft.AspNetCore.Mvc;
using static finance_backend.API.Dto.ErrorResponse;

namespace finance_backend.API.Controllers.Balances
{
    public partial class BalancesController
    {
        /// <summary>
        /// Получение пагинированного списка балансов для текущего пользователя.
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Balances/Paged
        ///     {
        ///        "page": 1,
        ///        "pageSize": 10
        ///     }
        /// </remarks>
        /// <param name="request">Модель запроса для получения пагинированного списка балансов: BalancePagedRequest.</param>
        /// <returns>Пагинированный список балансов для текущего пользователя.</returns>
        /// <response code="200">Пагинированный список балансов успешно получен.</response>
        /// <response code="400">Ошибка при запросе пагинированного списка балансов. Возвращается в случае неверных параметров запроса.</response>
        [HttpPost("paged")]
        [ProducesResponseType(typeof(PagedBalances), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<PagedBalances>> GetPagedBalancesForCurrentUser([FromBody] BalancePagedRequest request)
        {
            if (request.Page < 1 || request.Size <= 0)
            {
                var error = new ErrorItem("Page должен быть больше 0, Size должен быть больше 0.");
                var errorResponse = new ErrorResponse
                {
                    IsSuccess = false,
                    Errors = new List<ErrorItem> { error },
                };

                return BadRequest(errorResponse);
            }

            var balances = await _balanceService.GetPagedBalancesForCurrentUser(request);

            return Ok(balances);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using static finance_backend.API.Dto.ErrorResponse;

namespace finance_backend.API.Controllers.Balances;

public partial class BalancesController
{
    /// <summary>
    /// Удаление баланса по его идентификатору.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /Balance/{balanceId}
    /// </remarks>
    /// <param name="balanceId">Идентификатор баланса (GUID).</param>
    /// <returns>Результат удаления баланса.</returns>
    /// <response code="200">Баланс успешно удален.</response>
    /// <response code="400">Ошибка удаления баланса. Возвращается в случае неверного идентификатора баланса или других проблем при удалении.</response>
    [HttpDelete("{balanceId}")]
    [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(IEnumerable<ErrorItem>), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteBalance(Guid balanceId)
    {
        var result = await _balanceService.DeleteBalance(balanceId);

        if (result.IsSuccess)
        {
            return Ok("Баланс успешно удален");
        }

        return BadRequest(result.Errors);
    }

}
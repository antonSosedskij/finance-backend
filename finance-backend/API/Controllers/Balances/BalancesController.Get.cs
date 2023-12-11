using finance_backend.API.Dto;
using finance_backend.Application.Services.Balance.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Balances
{
    public partial class BalancesController
    {
        /// <summary>
        /// ��������� ���������� � ������� �� ��� ��������������.
        /// </summary>
        /// <remarks>
        /// ������ �������:
        ///
        ///     GET /Balances/{id}
        /// </remarks>
        /// <param name="id">������������� ������� (GUID).</param>
        /// <returns>���������� � �������.</returns>
        /// <response code="200">���������� � ������� ������� ��������.</response>
        /// <response code="400">������ �� ������. ������������ � ������ ���������� ������� � ��������� ���������������.</response>
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

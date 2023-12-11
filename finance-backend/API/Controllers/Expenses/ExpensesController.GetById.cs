using Microsoft.AspNetCore.Mvc;

namespace Finance_Backend.Controllers
{
    public partial class ExpensesController
    {
        /// <summary>
        /// ��������� ���������� � ������� �� ��� ��������������.
        /// </summary>
        /// <remarks>
        /// ������ �������:
        ///
        ///     GET /Expenses/{id}
        /// </remarks>
        /// <param name="id">������������� �������.</param>
        /// <returns>���������� � �������.</returns>
        /// <response code="200">���������� � ������� ������� ��������.</response>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var expense = await _expenseService.GetById(id);

            return Ok(expense);
        }

    }
}

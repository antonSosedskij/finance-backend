using finance_backend.Application.Services.Balance.Interfaces;
using finance_backend.Application.Services.Category.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Balances
{
    /// <summary>
    /// ���������� ��� ���������� ���������� � ���������.
    /// </summary>
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    [Route("api/[controller]")]
    public partial class BalancesController : ControllerBase
    {
        private readonly IBalanceService _balanceService;
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// ����������� ����������� ��������.
        /// </summary>
        /// <param name="balanceService">������ ��� ������ � ���������.</param>
        /// <param name="categoryService">������ ��� ������ � �����������.</param>
        public BalancesController(
            IBalanceService balanceService,
            ICategoryService categoryService)
        {
            _balanceService = balanceService;
            _categoryService = categoryService;
        }
    }
}

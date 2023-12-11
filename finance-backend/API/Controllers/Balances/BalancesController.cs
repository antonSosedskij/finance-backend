using finance_backend.Application.Services.Balance.Interfaces;
using finance_backend.Application.Services.Category.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.API.Controllers.Balances
{
    /// <summary>
    /// Контроллер для управления операциями с балансами.
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public partial class BalancesController : ControllerBase
    {
        private readonly IBalanceService _balanceService;
        private readonly ICategoryService _categoryService;

        /// <summary>
        /// Конструктор контроллера балансов.
        /// </summary>
        /// <param name="balanceService">Сервис для работы с балансами.</param>
        /// <param name="categoryService">Сервис для работы с категориями.</param>
        public BalancesController(
            IBalanceService balanceService,
            ICategoryService categoryService)
        {
            _balanceService = balanceService;
            _categoryService = categoryService;
        }
    }
}

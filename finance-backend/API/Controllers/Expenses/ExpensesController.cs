using finance_backend.Application.Services.Expense.Interfaces;
using finance_backend.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Finance_Backend.Controllers
{
    /// <summary>
    /// Контроллер для управления операциями с расходами.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public partial class ExpensesController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        /// <summary>
        /// Конструктор контроллера расходов.
        /// </summary>
        /// <param name="context">Контекст приложения.</param>
        /// <param name="expenseService">Сервис для работы с расходами.</param>
        public ExpensesController(ApplicationContext context, IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }
    }
}

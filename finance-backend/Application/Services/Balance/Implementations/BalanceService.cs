using finance_backend.API.Dto;
using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Balance.Contracts;
using finance_backend.Application.Services.Balance.Interfaces;
using finance_backend.Application.Services.Income.Interfaces;
using finance_backend.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static finance_backend.API.Dto.ErrorResponse;

namespace finance_backend.Application.Services.Balance.Implementations;

/// <summary>
/// Сервис для работы с балансами.
/// </summary>
public class BalanceService : IBalanceService
{
    private readonly IBalanceRepository _balanceRepository;
    private readonly IIncomeService _incomeService;
    private readonly IIdentityService _identityService;

    /// <summary>
    /// Конструктор службы для работы с балансами.
    /// </summary>
    /// <param name="balanceRepository">Репозиторий для работы с балансами.</param>
    /// <param name="categoryRepository">Репозиторий для работы с категориями.</param>
    /// <param name="incomeService">Сервис для работы с доходами.</param>
    /// <param name="identityService">Сервис для работы с идентификацией пользователя.</param>

    public BalanceService(
        IBalanceRepository balanceRepository,
        ICategoryRepository categoryRepository,
        IIncomeService incomeService,
        IIdentityService identityService)
    {
        _balanceRepository = balanceRepository;
        _incomeService = incomeService;
        _identityService = identityService;
    }

    /// <summary>
    /// Создание нового баланса в системе.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     POST /Balance/Create
    ///     {
    ///        "title": "Новый баланс",
    ///        "percent": 5.0,
    ///        "categoryId": "00000000-0000-0000-0000-000000000000" // Замените на реальный GUID
    ///     }
    /// </remarks>
    /// <param name="request">Модель запроса для создания баланса: CreateBalanceRequest.</param>
    /// <returns>Результат создания баланса.</returns>
    /// <response code="201">Баланс успешно создан.</response>
    /// <response code="400">Ошибка создания баланса. Возвращается в случае отсутствия категории, попытки создания баланса с тем же именем, что и дефолтный баланс 'Общий', или других проблем с запросом.</response>
    [HttpPost("create")]
    [ProducesResponseType(typeof(CreateBalanceResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]

    public async Task<CreateBalanceResponse> CreateBalance(CreateBalanceRequest request)
    {
        var currentUserId = await _identityService.GetCurrentUserId();

        if (request.Title == "Общий")
        {
            var error = new ErrorItem("Невозможно создать баланс с тем же именем, что и дефолтный баланс 'Общий'");
            return new CreateBalanceResponse
            {
                IsSuccess = false,
                Errors = new List<ErrorItem> { error }
            };
        }

        var balance = new Domain.Balance
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Percent = request.Percent,
            UserId = currentUserId,
            CategoryId = request.CategoryId,
            CreatedDate = DateTime.UtcNow,
        };

        var defaultCommonBalance = await _balanceRepository.GetDefaultCommonBalance(currentUserId);

        // Если дефолтный баланс существует, вычитаем указанный процент
        if (defaultCommonBalance != null)
        {
            defaultCommonBalance.Percent -= request.Percent;

            var updateRequest = new UpdateBalanceRequest
            {
                BalanceId = defaultCommonBalance.Id,
                Title = defaultCommonBalance.Title,
                Percent = defaultCommonBalance.Percent
            };

            await this.UpdateBalance(updateRequest);
        }

        // Сохраняем новый баланс
        await _balanceRepository.Save(balance);

        return new CreateBalanceResponse
        {
            IsSuccess = true,
            Data = balance.Id,
        };
    }

    /// <summary>
    /// Обновление информации о балансе в системе.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     PUT /Balance/Update
    ///     {
    ///        "balanceId": "00000000-0000-0000-0000-000000000000", // Замените на реальный GUID
    ///        "title": "Новое название баланса",
    ///        "percent": 7.5
    ///     }
    /// </remarks>
    /// <param name="request">Модель запроса для обновления баланса: UpdateBalanceRequest.</param>
    /// <returns>Результат обновления информации о балансе.</returns>
    /// <response code="200">Информация о балансе успешно обновлена.</response>
    /// <response code="400">Ошибка обновления баланса. Возвращается в случае неверного идентификатора баланса, попытки изменения несуществующего баланса или других проблем с запросом.</response>
    [HttpPut("update")]
    [ProducesResponseType(typeof(UpdateBalanceResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<UpdateBalanceResponse> UpdateBalance(UpdateBalanceRequest request)
    {
        var balance = await _balanceRepository.GetBalanceById(request.BalanceId);

        if (balance != null)
        {
            balance.Title = request.Title;
            balance.Percent = request.Percent;
            await _balanceRepository.Update(balance);

            return new UpdateBalanceResponse
            {
                IsSuccess = true,
                Data = new BalanceView
                {
                    Id = balance.Id,
                    Title = balance.Title,
                    Percent = balance.Percent,
                    CategoryName = balance.Category.Title,
                }
            };
        }

        var error = new ErrorItem("Баланс не найден");
        return new UpdateBalanceResponse
            {
                IsSuccess = false,
                Errors = new List<ErrorItem> { error }
            };
    }

    /// <summary>
    /// Получение информации о балансе по его идентификатору.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Balance/{id}
    /// </remarks>
    /// <param name="id">Идентификатор баланса (GUID).</param>
    /// <returns>Информация о балансе.</returns>
    /// <response code="200">Информация о балансе успешно получена.</response>
    /// <response code="404">Баланс не найден. Возвращается в случае отсутствия баланса с указанным идентификатором.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetBalanceResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]

    public async Task<GetBalanceResponse> GetBalance(Guid id)
    {
        var balance = await _balanceRepository.FindById(id);

        if (balance == null)
        {
            var error = new ErrorItem("Баланс не найден.");
            return new GetBalanceResponse { IsSuccess = false,
            Errors = new[] { error }
            };
        }
        var userIncomes = await _incomeService.GetUserIncomesSum();
        var availableAmount = (balance.Percent * userIncomes.IncomesSum) / 100;
        var expensesSum = balance.Expenses.Sum(i => i.Amount);

        return new GetBalanceResponse
        {
            IsSuccess = true,
            Data = new BalanceView
            {
                Id = balance.Id,
                Title = balance.Title,
                Percent = balance.Percent,
                AvailableAmount = availableAmount,
                ExpensesSum = expensesSum,
                CategoryName = balance.Category.Title,
            }
        };
    }

    /// <summary>
    /// Получение пагинированного списка балансов для текущего пользователя.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     GET /Balances/Paged
    ///     {
    ///        "page": 1,
    ///        "pageSize": 10
    ///     }
    /// </remarks>
    /// <param name="request">Модель запроса для получения пагинированного списка балансов: BalancePagedRequest.</param>
    /// <returns>Пагинированный список балансов для текущего пользователя.</returns>
    [HttpGet("Paged")]
    [ProducesResponseType(typeof(PagedBalances), StatusCodes.Status200OK)]
    public async Task<PagedBalances> GetPagedBalancesForCurrentUser(BalancePagedRequest request)
    {
        var userId = await _identityService.GetCurrentUserId();

        var balances = await _balanceRepository.GetPagedBalancesByUserId(userId, request);

        var balanceResponses = balances.Select(b => new BalanceView
        {
            Id = b.Id,
            Title = b.Title,
            Percent = b.Percent,
            CategoryName = b.Category.Title,
        });

        return new PagedBalances
        {
            Items = balanceResponses,
            TotalCount = balances.Count(),
        };
    }

    /// <summary>
    /// Удаление баланса по его идентификатору.
    /// </summary>
    /// <remarks>
    /// Пример запроса:
    ///
    ///     DELETE /Balances/{balanceId}
    /// </remarks>
    /// <param name="balanceId">Идентификатор удаляемого баланса (GUID).</param>
    /// <returns>Результат удаления баланса.</returns>
    /// <response code="200">Баланс успешно удален.</response>
    /// <response code="400">Ошибка удаления баланса. Возвращается в случае неверного идентификатора баланса или других проблем при удалении.</response>
    [HttpDelete("{balanceId}")]
    [ProducesResponseType(typeof(DeleteBalanceResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(DeleteBalanceResponse), StatusCodes.Status400BadRequest)]
    public async Task<DeleteBalanceResponse> DeleteBalance(Guid balanceId)
    {
        var balanceToDelete = await _balanceRepository.GetBalanceById(balanceId);

        if (balanceToDelete == null)
        {
            var error = new ErrorItem("Баланс не найден");
            return new DeleteBalanceResponse
            {
                IsSuccess = false,
                Errors = new List<ErrorItem> { error }
            };
        }

        var defaultCommonBalance = await _balanceRepository.GetDefaultCommonBalance(balanceToDelete.UserId);

        if (defaultCommonBalance != null)
        {
            defaultCommonBalance.Percent += balanceToDelete.Percent;
            await _balanceRepository.Update(defaultCommonBalance);
        }

        await _balanceRepository.Delete(balanceToDelete.Id);

        return new DeleteBalanceResponse { IsSuccess = true };
    }

}
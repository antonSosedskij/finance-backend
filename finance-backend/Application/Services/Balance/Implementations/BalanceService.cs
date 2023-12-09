using System.Security.Principal;
using finance_backend.API.Dto;
using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Balance.Contracts;
using finance_backend.Application.Services.Balance.Interfaces;
using finance_backend.Application.Services.Income.Interfaces;
using Microsoft.EntityFrameworkCore;
using static finance_backend.API.Dto.ErrorResponse;

namespace finance_backend.Application.Services.Balance.Implementations;

public class BalanceService : IBalanceService
{
    private readonly IBalanceRepository _balanceRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IIncomeService _incomeService;
    private readonly IIdentityService _identityService;

    public BalanceService(
        IBalanceRepository balanceRepository,
        ICategoryRepository categoryRepository,
        IIncomeService incomeService,
        IIdentityService identityService)
    {
        _balanceRepository = balanceRepository;
        _categoryRepository = categoryRepository;
        _incomeService = incomeService;
        _identityService = identityService;
    }

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
                    Percent = balance.Percent
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


    public async Task<GetBalance.Response> GetBalance(GetBalance.Request request)
    {
        var balance = await _balanceRepository.FindById(request.Id);

        var userIncomes = await _incomeService.GetUserIncomesSum();
        var availableAmount = (balance.Percent * userIncomes.IncomesSum) / 100;
        var expensesSum = balance.Expenses.Sum(i => i.Amount);

        return new GetBalance.Response
        {
            Id = balance.Id,
            Title = balance.Title,
            Percent = balance.Percent,
            AvailableAmount = availableAmount,
            ExpensesSum = expensesSum,
            Category = new GetBalance.Response.BalancesCategory
            {
                Id = balance.Category.Id,

                Title = balance.Category.Title
            }
        };
    }

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
            UserId = b.User.Id,
        });

        return new PagedBalances
        {
            Items = balanceResponses,
            TotalCount = balances.Count(),
        };
    }

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
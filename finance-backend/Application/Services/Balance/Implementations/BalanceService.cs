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
/// ������ ��� ������ � ���������.
/// </summary>
public class BalanceService : IBalanceService
{
    private readonly IBalanceRepository _balanceRepository;
    private readonly IIncomeService _incomeService;
    private readonly IIdentityService _identityService;

    /// <summary>
    /// ����������� ������ ��� ������ � ���������.
    /// </summary>
    /// <param name="balanceRepository">����������� ��� ������ � ���������.</param>
    /// <param name="categoryRepository">����������� ��� ������ � �����������.</param>
    /// <param name="incomeService">������ ��� ������ � ��������.</param>
    /// <param name="identityService">������ ��� ������ � �������������� ������������.</param>

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
    /// �������� ������ ������� � �������.
    /// </summary>
    /// <remarks>
    /// ������ �������:
    ///
    ///     POST /Balance/Create
    ///     {
    ///        "title": "����� ������",
    ///        "percent": 5.0,
    ///        "categoryId": "00000000-0000-0000-0000-000000000000" // �������� �� �������� GUID
    ///     }
    /// </remarks>
    /// <param name="request">������ ������� ��� �������� �������: CreateBalanceRequest.</param>
    /// <returns>��������� �������� �������.</returns>
    /// <response code="201">������ ������� ������.</response>
    /// <response code="400">������ �������� �������. ������������ � ������ ���������� ���������, ������� �������� ������� � ��� �� ������, ��� � ��������� ������ '�����', ��� ������ ������� � ��������.</response>
    [HttpPost("create")]
    [ProducesResponseType(typeof(CreateBalanceResponse), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]

    public async Task<CreateBalanceResponse> CreateBalance(CreateBalanceRequest request)
    {
        var currentUserId = await _identityService.GetCurrentUserId();

        if (request.Title == "�����")
        {
            var error = new ErrorItem("���������� ������� ������ � ��� �� ������, ��� � ��������� ������ '�����'");
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

        // ���� ��������� ������ ����������, �������� ��������� �������
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

        // ��������� ����� ������
        await _balanceRepository.Save(balance);

        return new CreateBalanceResponse
        {
            IsSuccess = true,
            Data = balance.Id,
        };
    }

    /// <summary>
    /// ���������� ���������� � ������� � �������.
    /// </summary>
    /// <remarks>
    /// ������ �������:
    ///
    ///     PUT /Balance/Update
    ///     {
    ///        "balanceId": "00000000-0000-0000-0000-000000000000", // �������� �� �������� GUID
    ///        "title": "����� �������� �������",
    ///        "percent": 7.5
    ///     }
    /// </remarks>
    /// <param name="request">������ ������� ��� ���������� �������: UpdateBalanceRequest.</param>
    /// <returns>��������� ���������� ���������� � �������.</returns>
    /// <response code="200">���������� � ������� ������� ���������.</response>
    /// <response code="400">������ ���������� �������. ������������ � ������ ��������� �������������� �������, ������� ��������� ��������������� ������� ��� ������ ������� � ��������.</response>
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

        var error = new ErrorItem("������ �� ������");
        return new UpdateBalanceResponse
            {
                IsSuccess = false,
                Errors = new List<ErrorItem> { error }
            };
    }

    /// <summary>
    /// ��������� ���������� � ������� �� ��� ��������������.
    /// </summary>
    /// <remarks>
    /// ������ �������:
    ///
    ///     GET /Balance/{id}
    /// </remarks>
    /// <param name="id">������������� ������� (GUID).</param>
    /// <returns>���������� � �������.</returns>
    /// <response code="200">���������� � ������� ������� ��������.</response>
    /// <response code="404">������ �� ������. ������������ � ������ ���������� ������� � ��������� ���������������.</response>
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetBalanceResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status404NotFound)]

    public async Task<GetBalanceResponse> GetBalance(Guid id)
    {
        var balance = await _balanceRepository.FindById(id);

        if (balance == null)
        {
            var error = new ErrorItem("������ �� ������.");
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
    /// ��������� ��������������� ������ �������� ��� �������� ������������.
    /// </summary>
    /// <remarks>
    /// ������ �������:
    ///
    ///     GET /Balances/Paged
    ///     {
    ///        "page": 1,
    ///        "pageSize": 10
    ///     }
    /// </remarks>
    /// <param name="request">������ ������� ��� ��������� ��������������� ������ ��������: BalancePagedRequest.</param>
    /// <returns>�������������� ������ �������� ��� �������� ������������.</returns>
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
    /// �������� ������� �� ��� ��������������.
    /// </summary>
    /// <remarks>
    /// ������ �������:
    ///
    ///     DELETE /Balances/{balanceId}
    /// </remarks>
    /// <param name="balanceId">������������� ���������� ������� (GUID).</param>
    /// <returns>��������� �������� �������.</returns>
    /// <response code="200">������ ������� ������.</response>
    /// <response code="400">������ �������� �������. ������������ � ������ ��������� �������������� ������� ��� ������ ������� ��� ��������.</response>
    [HttpDelete("{balanceId}")]
    [ProducesResponseType(typeof(DeleteBalanceResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(DeleteBalanceResponse), StatusCodes.Status400BadRequest)]
    public async Task<DeleteBalanceResponse> DeleteBalance(Guid balanceId)
    {
        var balanceToDelete = await _balanceRepository.GetBalanceById(balanceId);

        if (balanceToDelete == null)
        {
            var error = new ErrorItem("������ �� ������");
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
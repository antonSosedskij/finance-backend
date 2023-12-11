using finance_backend.API.Dto;
using finance_backend.Application.Identity.Contracts;
using finance_backend.Application.Identity.Interfaces;
using finance_backend.Application.Repositories;
using finance_backend.Application.Services.Category.Interfaces;
using finance_backend.Application.Services.User.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.Application.Services.User.Implementaitions;

/// <summary>
/// Сервис для работы с пользователями.
/// </summary>
public class UserService : IUserService
{
    private readonly IRepository<Domain.User, Guid> _repository;
    private readonly IIdentityService _identity;
    private readonly ICategoryService _categoryService;

    /// <summary>
    /// Конструктор сервиса для работы с пользователями.
    /// </summary>
    /// <param name="repository">Репозиторий для работы с пользователями.</param>
    /// <param name="identity">Сервис для работы с идентификацией.</param>
    /// <param name="categoryService">Сервис для работы с категориями.</param>
    public UserService( 
        IRepository<Domain.User, Guid> repository,
        IIdentityService identity,
        ICategoryService categoryService)
    {
        _repository = repository;
        _identity = identity;
        _categoryService = categoryService;
    }

    /// <summary>
    /// Метод для регистрации нового пользователя.
    /// </summary>
    /// <param name="request">Модель запроса для регистрации: SignUpRequest.</param>
    /// <returns>Результат регистрации пользователя: SignUpResponse.</returns>
    /// <response code="200">Регистрация выполнена успешно.</response>
    /// <response code="400">Ошибка регистрации. Возвращается в случае неверных данных или других проблем при регистрации.</response>
    [HttpPost("signup")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(SignUpResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<SignUpResponse> SignUp(SignUpRequest request)
    {
        var response = await _identity.SignUp(new SignUpRequest
        {
            Username = request.Username,
            Email = request.Email,
            Password = request.Password,
            Name = request.Name,
            Lastname = request.Lastname,
        });

        if (response.IsSuccess)
        {
            var domainUser = new Domain.User
            {
                Id = response.Data,
                Username = request.Username,
                Name = request.Name,
                Lastname = request.Lastname,
                Email = request.Email,
                CreatedDate = DateTime.UtcNow,
            };

            await _repository.Save(domainUser);

            await _categoryService.CreateDefaultCategories(response.Data);

            return new SignUpResponse
            {
                IsSuccess = true,
                Data = response.Data,
            };
        }

        return new SignUpResponse
        {
            IsSuccess = false,
            Errors = response.Errors.ToArray(),
        };
    }

    /// <summary>
    /// Метод для аутентификации пользователя.
    /// </summary>
    /// <param name="request">Модель запроса для аутентификации: SignInRequest.</param>
    /// <returns>Результат аутентификации пользователя: SignInResponse.</returns>
    /// <response code="200">Аутентификация выполнена успешно.</response>
    /// <response code="400">Ошибка аутентификации. Возвращается в случае неверных учетных данных или других проблем с аутентификацией.</response>
    [HttpPost("signin")]
    [AllowAnonymous]
    [ProducesResponseType(typeof(SignInResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ErrorResponse), StatusCodes.Status400BadRequest)]
    public async Task<SignInResponse> SignIn(SignInRequest request)
    {
        var response = await _identity.SignIn(new SignInRequest
        {
            Email = request.Email,
            Password = request.Password,
        });

        if (response.IsSuccess)
        {
            return new SignInResponse
            {
                IsSuccess = true,
                Data = new SignInSuccessResponse
                {
                    Token = response.Data.Token,
                    Id = response.Data.Id,
                    Username = response.Data.Username,
                },
            };
        }

        return new SignInResponse
        {
            IsSuccess = false,
            Errors = response.Errors.ToArray(),
        };
    }
}
using finance_backend.Application.Services.User.Contracts;

namespace finance_backend.Application.Services.User.Interfaces;

public interface IUserService
{
    public Task<Register.Response> Register(Register.Request request);
}
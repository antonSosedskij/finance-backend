using finance_backend.Application.Identity.Contracts;

namespace finance_backend.Application.Identity.Interfaces;

public interface IIdentityService
{
    Task<CreateUser.Response> CreateUser(CreateUser.Request request);

    Task<CreateToken.Response> CreateToken(CreateToken.Request request);

}
using finance_backend.Application.Identity.Contracts;

namespace finance_backend.Application.Services.User.Interfaces;

public interface IUserService
{
    public Task<SignUpResponse> SignUp(SignUpRequest request);
    public Task<SignInResponse> SignIn(SignInRequest request);
}
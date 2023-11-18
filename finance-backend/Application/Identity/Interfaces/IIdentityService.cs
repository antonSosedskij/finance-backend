using finance_backend.Application.Identity.Contracts;

namespace finance_backend.Application.Identity.Interfaces;

public interface IIdentityService
{
    Task<Guid> GetCurrentUserId();
    Task<SignUpResponse> SignUp(SignUpRequest request);

    Task<SignInResponse> SignIn(SignInRequest request);

}
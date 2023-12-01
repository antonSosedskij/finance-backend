namespace finance_backend.Application.Identity.Contracts;

public class SignInRequest
{
    public string Email { get; set; }

    public string Password { get; set; }
}

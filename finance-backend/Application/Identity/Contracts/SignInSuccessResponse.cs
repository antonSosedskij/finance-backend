namespace finance_backend.Application.Identity.Contracts;

public class SignInSuccessResponse
{
    public string Token { get; set; }
    public string Username { get; set; }
    public Guid Id { get; set; }
}
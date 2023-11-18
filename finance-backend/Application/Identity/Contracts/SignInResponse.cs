namespace finance_backend.Application.Identity.Contracts;

public class SignInResponse 
{
    public bool IsSuccess { get; set; }
    public string Token { get; set; }
    public string Username { get; set; }
    public Guid Id { get; set; }
    public string[] Errors { get; set; }
}
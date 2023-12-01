namespace finance_backend.Application.Identity.Contracts;

public class SignUpResponse
{
    public bool IsSuccess { get; set; }
    public Guid Id { get; set; }
    public string[] Errors { get; set; }
}
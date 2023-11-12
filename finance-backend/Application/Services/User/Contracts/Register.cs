namespace finance_backend.Application.Services.User.Contracts;

public class Register
{
    public sealed class Request
    {
        public string Username { get; set; }
    
        public string Email { get; set; }
    
        public string Name { get; set; }
    
        public string Lastname { get; set; }
    
        public string Password { get; set; }
    }

    public sealed class Response
    {
        public Guid Id { get; set; }
    }
}
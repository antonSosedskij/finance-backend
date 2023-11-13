namespace finance_backend.Application.Identity.Contracts;

public static class CreateToken
{
    public class Request
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

    public class Response
    {
        public string Token { get; set; }
        public string Username { get; set; }
        public Guid Id { get; set; }
    }
}
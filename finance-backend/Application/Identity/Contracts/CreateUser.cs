namespace finance_backend.Application.Identity.Contracts;

public static class CreateUser
{
    public class Request
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public class Response
    {
        public bool IsSuccess { get; set; }
        public Guid Id { get; set; }
        public string[] Errors { get; set; }
    }
}
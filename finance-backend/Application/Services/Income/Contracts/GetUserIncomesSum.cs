namespace finance_backend.Application.Services.Income.Contracts;

public static class GetUserIncomesSum
{
    public sealed class Request
    {

    }
    
    public sealed class Response
    {
        public Guid UserId { get; set; }
        public decimal IncomesSum { get; set; }
    }
}
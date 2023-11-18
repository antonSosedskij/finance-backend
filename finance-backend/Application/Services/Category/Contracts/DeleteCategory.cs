namespace finance_backend.Application.Services.Category.Contracts;

public static class DeleteCategory
{
    public sealed class Request
    {
        public Guid Id { get; set; }
    }
}
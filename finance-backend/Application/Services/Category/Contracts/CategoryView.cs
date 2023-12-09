namespace finance_backend.Application.Services.Category.Contracts
{
    public class CategoryView
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Owner User { get; set; }

        public sealed class Owner
        {
            public Guid Id { get; set; }
            public string Username { get; set; }
            public string Email { get; set; }
            public string Name { get; set; }
            public string Lastname { get; set; }
        }
    }
}

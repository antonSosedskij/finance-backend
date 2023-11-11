using finance_backend.DataAccess.Models;
using finance_backend.Domain.Shared;

namespace finance_backend.Domain
{
    public class User : MutableEntity<Guid>
    {
        public User()
        {
            Category defaultCategory = new Category { Title = "Основное", UserId = Id };
            Categories = new List<Category> { defaultCategory };
            Balances = new List<Balance>
            {
                new Balance { CategoryId = defaultCategory.Id, Percent = 100 }
            };
        }

        public string Username { get; set; }

        public string Email { get; set; }

        public ICollection<Category> Categories { get; set; }

        public ICollection<Balance> Balances { get; set; }

    }
}

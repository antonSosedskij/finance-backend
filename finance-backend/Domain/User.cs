using finance_backend.DataAccess.Models;
using finance_backend.Domain.Shared;

namespace finance_backend.Domain
{
    public class User : MutableEntity<Guid>
    {
        
        public string Username { get; set; }

        public string Email { get; set; }
        
        public string Name { get; set; }
        
        public string Lastname { get; set; }
        
        public ICollection<Category> Categories { get; set; }
    }
}

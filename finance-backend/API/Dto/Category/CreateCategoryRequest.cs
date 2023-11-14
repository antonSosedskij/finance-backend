namespace finance_backend.API.Dto.Category;

public class CreateCategoryRequest
{
    public string Title { get; set; }
    
    public Guid UserId { get; set; }
}
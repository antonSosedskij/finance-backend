namespace finance_backend.API.Dto;

public class CreateCategoryRequest
{
    public string Title { get; set; }
    
    public Guid UserId { get; set; }
}
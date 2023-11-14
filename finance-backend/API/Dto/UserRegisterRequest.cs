namespace finance_backend.API.Dto;

public class UserRegisterRequest
{
    public string Username { get; set; }
    
    public string Email { get; set; }
    
    public string Name { get; set; }
    
    public string Lastname { get; set; }
    
    public string Password { get; set; }
}
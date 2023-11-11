using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finance_backend.Data_access.Models;

public class Income
{
    public Guid Id { get; set; }

    public string Title { get; set; } = "";
    
    public float Amount { get; set; }
    
}
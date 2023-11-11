using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finance_backend.Data_access.Models;

public class Income
{
    public Guid id { get; set; }

    public string title { get; set; } = "";
    
    public float amount { get; set; }
    
}
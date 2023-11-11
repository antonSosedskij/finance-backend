using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finance_backend.Data_access.Models;

public class Balance
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid id { get; set; }
    
    public float percent { get; set; }
    
    public Guid categoryId { get; set; }
}
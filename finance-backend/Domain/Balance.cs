using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace finance_backend.Data_access.Models;

public class Balance
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    
    public float Percent { get; set; }
    
    public Guid CategoryId { get; set; }
}
using finance_backend.Data_access.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.Controllers;

[ApiController]
public class IncomeController
{
    public ApplicationContext db;
    
    public IncomeController(ApplicationContext context)
    {
        db = context;
    }
    
    [HttpGet("api/incomes")]
    public IEnumerable<Income> Get()
    {
        return db.incomes.ToList();
    }
    
    [HttpPost("api/incomes")]
    public Income Post(Income income)
    {
        
        db.incomes.Add(income);
        db.SaveChanges();
        return income;
    }
}
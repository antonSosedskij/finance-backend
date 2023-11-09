using finance_backend.Data_access.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.Controllers;

[ApiController]
[Route("api/incomes")]
public class IncomeController : Controller
{
    public ApplicationContext db;
    
    public IncomeController(ApplicationContext context)
    {
        db = context;
    }
    
    [HttpGet]
    public IEnumerable<Income> Get()
    {
        return db.incomes.ToList();
    }
    
    [HttpGet("{id})")]
    public Income Get(Guid id)
    {
        Income income = db.incomes.Find(id);
        return income;
    }
    
    [HttpPost]
    public Income Post(Income income)
    {
        
        db.incomes.Add(income);
        db.SaveChanges();
        return income;
    }
    
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Income request)
    {
        if (id != request.id)
        {
            BadRequest("Invalid request");
        }
        
        Income existingIncome = db.incomes.FirstOrDefault(i => i.id == id);

        if (existingIncome == null)
        {
            return NotFound();
        }

        existingIncome.title = request.title;
        existingIncome.amount = request.amount;

        db.SaveChanges();
        return Ok(existingIncome);
    }
}
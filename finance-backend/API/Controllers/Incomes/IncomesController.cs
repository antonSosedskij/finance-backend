using finance_backend.Application.Services.Income.Interfaces;
using finance_backend.DataAccess.Models;
using finance_backend.Domain;
using finance_backend.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace finance_backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public partial class IncomesController : Controller
{
    private readonly ApplicationContext db;
    private readonly IIncomeService _incomeService;
    
    public IncomesController(ApplicationContext context, IIncomeService incomeService)
    {
        db = context;
        _incomeService = incomeService;
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
    
    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Income request)
    {
        if (id != request.Id)
        {
            BadRequest("Invalid request");
        }
        
        Income existingIncome = db.incomes.FirstOrDefault(i => i.Id == id);

        if (existingIncome == null)
        {
            return NotFound();
        }

        existingIncome.Title = request.Title;
        existingIncome.Amount = request.Amount;

        db.SaveChanges();
        return Ok(existingIncome);
    }
}
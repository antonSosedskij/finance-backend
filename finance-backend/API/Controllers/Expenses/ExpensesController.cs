﻿using finance_backend.Application.Services.Expense.Interfaces;
using finance_backend.DataAccess.Models;
using finance_backend.Domain;
using finance_backend.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Finance_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class ExpensesController : ControllerBase
    {
        private readonly ApplicationContext _context;
        private readonly IExpenseService _expenseService;

        public ExpensesController(ApplicationContext context, IExpenseService expenseService)
        {
            _context = context;
            _expenseService = expenseService;
        }

        // GET: api/Expenses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Expense>>> GetExpense()
        {
          if (_context.expenses == null)
          {
              return NotFound();
          }
            return await _context.expenses.ToListAsync();
        }

        // GET: api/Expenses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Expense>> GetExpense(Guid id)
        {
          if (_context.expenses == null)
          {
              return NotFound();
          }
            var expense = await _context.expenses.FindAsync(id);

            if (expense == null)
            {
                return NotFound();
            }

            return Ok(expense);
        }

        // PUT: api/Expenses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExpense(Guid id, Expense expense)
        {
            if (id != expense.Id)
            {
                return BadRequest();
            }

            _context.Entry(expense).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExpenseExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }
        

        // DELETE: api/Expenses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpense(Guid id)
        {
            if (_context.expenses == null)
            {
                return NotFound();
            }
            var expense = await _context.expenses.FindAsync(id);
            if (expense == null)
            {
                return NotFound();
            }

            _context.expenses.Remove(expense);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExpenseExists(Guid id)
        {
            return (_context.expenses?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication3.DatabaseContext;
using WebApplication3.Models;

namespace WebApplication3.Controllers;

public class EmployeeController : Controller
{
	private readonly ApplicationContext context;

	public EmployeeController(ApplicationContext context)
        {
		this.context = context;
	}
	[HttpGet]
        public async Task<IActionResult>  Index()
	{
		var data = await context.Set<Employee>().AsNoTracking().ToListAsync();
		return View(data);
	}
	[HttpGet]
    public async Task<IActionResult> CreateAndEdit(int id)
	{
        if (id == 0)
        {
            return View(new Employee());
        }
        else
        {
            var data = await context.Set<Employee>().FindAsync(id);
            return View(data);
        }
    }
    [HttpPost]
    public async Task<IActionResult> CreateAndEdit(int id,Employee employee)
    {
        if (id ==0)
        {
            if (ModelState.IsValid)
            {
                await context.Set<Employee>().AddAsync(employee);
                await context.SaveChangesAsync();  
                return RedirectToAction("Index");
            }
        }
        else
        {
            context.Set<Employee>().Update(employee);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(new Employee());
    }

    public async Task<IActionResult> Delete(int id)
    {
        if (id!=0)
        {
            var data = await context.Set<Employee>().FindAsync(id);
            if (data is not null)
            {
                context.Set<Employee>().Remove(data);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
        }
        return RedirectToAction("Index");
    }
    public async Task<IActionResult> Details(int id)
    {
        var data = await context.Set<Employee>().FindAsync(id);
        return View(data);
    }
}
